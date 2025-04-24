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
    public class TeamService : ITeamService
    {

        private readonly IRepository<Team> _teamRepository;

        public TeamService(IRepository<Team> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Team DeleteById(Guid id)
        {
            var team = _teamRepository.Get(selector: x => x,
                                                predicate: x => x.Id == id);
            return _teamRepository.Delete(team);
        }

        public List<Team> GetAll()
        {
            return _teamRepository.GetAll(selector: x => x).ToList();
        }

        public Team? GetById(Guid id)
        {
            return _teamRepository.Get(selector: x => x,
                                            predicate: x => x.Id == id);
        }

        public Team Insert(Team team)
        {
            team.Id = Guid.NewGuid();
            return _teamRepository.Insert(team);
        }

        public Team Update(Team team)
        {
            return _teamRepository.Update(team);
        }
    }
}
