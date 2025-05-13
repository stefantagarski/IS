using Game.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Game.Service.Interface
{
    public interface IParticipationService
    {  
        public Participation AddParticipationForAthleteAndCompetition(Guid athleteId, Guid competitionId, string userId);

        public List<Participation> GetAllByCurrentUser(string userId);
        public Participation GetById(Guid id);
        public Participation DeleteById(Guid id);
    }
}
