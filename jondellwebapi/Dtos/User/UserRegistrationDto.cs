using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Dtos.User
{
    public class UserRegistrationDto
    {
        public string Username { get; set;}
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
