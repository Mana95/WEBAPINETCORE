using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Account
    {
        public string id { get; set; }
        public string accountType { get; set; }

        public List<Balance> balance { get; set; }

    }
}
