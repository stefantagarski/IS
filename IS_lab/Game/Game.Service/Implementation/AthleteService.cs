using Game.Domain.DomainModels;
using Game.Repository;
using Game.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service.Implementation
{
    public class AthleteService : IAthleteService
    {
        private readonly IRepository<Athlete> _athleteRepository;

        public AthleteService(IRepository<Athlete> athleteRepository)
        {
            _athleteRepository = athleteRepository;
        }

        public Athlete DeleteById(Guid id)
        {
            var athlete = _athleteRepository.Get(selector: x => x,
                                                predicate: x => x.Id == id);
            return _athleteRepository.Delete(athlete);
        }

        public List<Athlete> GetAll()
        {
            return _athleteRepository.GetAll(selector: x => x).ToList();
        }

        public Athlete? GetById(Guid id)
        {
            return _athleteRepository.Get(selector: x => x,
                                           predicate: x => x.Id == id);
        }

        public Athlete Insert(Athlete athlete)
        {
           athlete.Id = Guid.NewGuid();
           return _athleteRepository.Insert(athlete);
        }

        public Athlete Update(Athlete athlete)
        {
            return _athleteRepository.Update(athlete);
        }
    }
}
