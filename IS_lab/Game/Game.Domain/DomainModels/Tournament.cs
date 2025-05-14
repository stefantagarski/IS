using Game.Domain.Idenity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.DomainModels
{
    public class Tournament : BaseEntity
    {
        public DateTime DateCreated { get; set; }
        public string? OwnerId { get; set; }
        public AthletesApplicationUser? User { get; set; }

        public virtual ICollection<AthleteInTournament>? AthleteInTournaments { get; set; } = new List<AthleteInTournament>();
    }
}
