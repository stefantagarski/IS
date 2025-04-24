using Game.Domain.DomainModels;
using Game.Repository;
using Game.Service.Interface;
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
            var athlete = _athleteRepository.Get(selector: x => x, predicate: x => x.Id == athleteId);

            var competition = _competitionRepository.Get(selector: x => x, predicate: x => x.Id == competitionId);

            var exsistingParticipation = _participationRepository.Get(selector: x => x,
                predicate: x => x.AthleteId == athlete.Id && x.CompetitionId == competition.Id && x.userId == userId);

            if (exsistingParticipation != null)
            {
              return _participationRepository.Update(exsistingParticipation);
            }
            else
            {
                var participation = new Participation
                {
                    Id = Guid.NewGuid(),
                    AthleteId = athlete.Id,
                    Athlete = athlete,
                    Competition = competition,
                    CompetitionId = competition.Id,
                    DateRegistered = DateTime.Now,
                    userId = userId
                };

                return _participationRepository.Insert(participation);
            }
        }
    }
}
