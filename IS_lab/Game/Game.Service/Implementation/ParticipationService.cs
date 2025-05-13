using Game.Domain.DomainModels;
using Game.Repository;
using Game.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Game.Service.Implementation
{
    public class ParticipationService : IParticipationService
    {
        private readonly IRepository<Participation> _participationRepository;
        private readonly IRepository<Athlete> _athleteRepository;
        private readonly IRepository<Competition> _competitionRepository;

        public ParticipationService(IRepository<Participation> participationRepository, IRepository<Athlete> athleteRepository, IRepository<Competition> competitionRepository)
        {
            _participationRepository = participationRepository;
            _athleteRepository = athleteRepository;
            _competitionRepository = competitionRepository;
        }

        public Participation AddParticipationForAthleteAndCompetition(Guid athleteId, Guid competitionId, string userId)
        {           
                var newParticipation = new Participation
                {
                    AthleteId = athleteId,
                    CompetitionId = competitionId,
                    DateRegistered = DateTime.Now,
                    OwnerId = userId
                };

            return _participationRepository.Insert(newParticipation);
        }
       
        //TODO
        public List<Participation> GetAllByCurrentUser(string userId)
        {
            return _participationRepository.GetAll(selector: x => x,
                predicate: x => x.OwnerId == userId,
                include: x => x.Include(y => y.Athlete).ThenInclude(z => z.Participations).
                Include(x => x.Competition).Include(x => x.Owner)).ToList();

        }

        //TODO
        public Participation GetById(Guid id)
        {
            return _participationRepository.Get(selector: x => x,
                predicate: x => x.OwnerId == id.ToString(),
                include: x => x.Include(y => y.Athlete).ThenInclude(z => z.Participations).
                Include(x => x.Competition).Include(x => x.Owner));
        }

        //TODO
        public Participation DeleteById(Guid id)
        {
            var partc = _participationRepository.Get(selector: x => x, predicate: x => x.Id == id);

            if (partc == null)
            {
                throw new Exception("This participation does not exist");
            }

            _participationRepository.Delete(partc);
            return partc;
        }
    }
}
