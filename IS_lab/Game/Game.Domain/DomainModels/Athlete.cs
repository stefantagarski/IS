using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.DomainModels
{
    public class Athlete : BaseEntity
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public int JerseyNumber { get; set; }
        public DateOnly DateJoined { get; set; }

        public Guid TeamId { get; set; }
        public Team? Team { get; set; }

        public virtual ICollection<Participation>? Participations { get; set; }

    }
}
