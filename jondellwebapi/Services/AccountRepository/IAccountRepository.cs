using jondellwebapi.Dtos.Balance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace jondellwebapi.Services.AccountRepository
{
   public interface IAccountRepository
    {
        Task<ServiceResponse<List<Balance>>> GetAllBalance();

        Task<ServiceResponse<List<Balance>>> GetBalanceByDateRange();

        Task<ServiceResponse<string>> SaveBalanceSheet(List<AddBalanceDto> balance);

    }
}
