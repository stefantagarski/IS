using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.DomainModels
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int FoundedYear { get; set; }

        public virtual ICollection<Athlete>? Athletes { get; set; }
    }
}
