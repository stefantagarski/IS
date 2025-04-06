using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.DomainModels
{
    public class Competition
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? StartDate { get; set; }

        public virtual ICollection<Participation>? Participations { get; set; }
    }
}
