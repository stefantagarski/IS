using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.DomainModels
{
    public class Participation
    {
        [Key]
        public Guid Id { get; set; }
        public string? DateRegistered { get; set; }
        public string? Result { get; set; }
        public int Performance { get; set; }

        public Guid CompetitionId { get; set; }
        public Competition? Competition { get; set; }
        public Guid AthleteId { get; set; }
        public Athlete? Athlete { get; set; }
    }
}
