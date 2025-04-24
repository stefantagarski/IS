using Game.Domain.Idenity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.DomainModels
{
    public class Participation : BaseEntity
    {
        public Competition? Competition { get; set; }
        public Guid CompetitionId { get; set; }
        public Athlete? Athlete { get; set; }
        public Guid AthleteId { get; set; }
        public DateTime DateRegistered { get; set; }

        public string? userId { get; set; }
        public AthletesApplicationUser? User { get; set; }
    }
}
