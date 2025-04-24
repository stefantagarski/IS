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
    public class CompetitionService : ICompetitionService
    {
        private readonly IRepository<Competition> _compRepository;

        public CompetitionService(IRepository<Competition> compRepository)
        {
            _compRepository = compRepository;
        }

        public Competition DeleteById(Guid id)
        {
            var comp = _compRepository.Get(selector: x => x,
                                                predicate: x => x.Id == id);
            return _compRepository.Delete(comp);
        }

        public List<Competition> GetAll()
        {
            return _compRepository.GetAll(selector: x => x).ToList();
        }

        public Competition? GetById(Guid id)
        {
            return _compRepository.Get(selector: x => x,
                                            predicate: x => x.Id == id);
        }

        public Competition Insert(Competition competition)
        {
            competition.Id = competition.Id;
            return _compRepository.Insert(competition);
        }

        public Competition Update(Competition competition)
        {
            return _compRepository.Update(competition);
        }
    }
}
