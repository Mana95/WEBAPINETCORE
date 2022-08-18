using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace jondellwebapi.Dtos.Balance
{
    public class AddBalanceDto
    {
        public string date { get; set; }
        public string balance { get; set; }

        public string AccountId { get; set; }

    }
}
