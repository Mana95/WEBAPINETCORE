using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace jondellwebapi.Dtos.Balance
{
    public class GetBalanceDto
    {
        public int id { get; set; }
        public string date { get; set; }
        public string balance { get; set; }

        public Account Account { get; set; }
    }
}
