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
        Task<ServiceResponse<List<GetBalanceDto>>> GetAllBalance();

        Task<ServiceResponse<List<GetBalanceDto>>> GetBalanceByDateRange(string fromDate , string toDate);

        Task<ServiceResponse<string>> SaveBalanceSheet(List<AddBalanceDto> balance);

    }
}
