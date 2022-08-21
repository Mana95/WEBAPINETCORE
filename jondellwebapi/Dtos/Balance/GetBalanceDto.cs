using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace jondellwebapi.Dtos.Balance
{
    public class GetBalanceDto
    {
        public string id { get; set; }
        public string date { get; set; }
        public double balance { get; set; }

 
        public string accountId { get; set; }

    }
}
