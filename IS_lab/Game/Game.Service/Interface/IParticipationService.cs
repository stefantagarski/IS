﻿using Game.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service.Interface
{
    public interface IParticipationService
    {  
        public Participation AddParticipationForAthleteAndCompetition(Guid athleteId, Guid competitionId, string userId);
    }
}
