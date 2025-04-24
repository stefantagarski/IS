using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.DomainModels
{
    public class Competition : BaseEntity
    {
        public string? Name { get; set; }
        public DateOnly StartDate { get; set; }

        public virtual ICollection<Participation>? Participations { get; set; }
    }
}
