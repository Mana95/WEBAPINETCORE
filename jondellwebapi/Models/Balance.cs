using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Balance
    {
        public int id { get; set; }
        public string date { get; set; }
        public string balance { get; set; }

        public string accountId { get; set; }
        public Account Account { get; set; }
    }
}
