using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.DomainModels
{
    public class UserDTO
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
