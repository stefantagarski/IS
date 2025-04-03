using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.DomainModels
{
    public class Athlete
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? DateOfBirth { get; set; }
        [Required]
        public int JerseyNumber { get; set; }
        public string? DateJoined { get; set; }

        public Guid TeamId { get; set; }
        public Team? Team { get; set; }

        public virtual ICollection<Participation>? Participations { get; set; }

    }
}
