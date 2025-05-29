using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication.Domain.DomainModels
{
    public class BookDTO
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? authorFirstName { get; set; }
        public string? authorLastName { get; set; }
        public string? isbnCode { get; set; }
        public string? shortDescription { get; set; }
        public int publishedYear { get; set; }
        public string? genre { get; set; }
        public int pageCount { get; set; }
        public string? language { get; set; }
        public string? availabilityStatus { get; set; }
    }
}
