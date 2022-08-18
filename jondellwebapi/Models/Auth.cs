using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jondellwebapi.Models
{
    public class Auth
    {
        public string token { get; set; }

        public string expiredIn { get; set; }
        public string role { get; set; }
    }
}
