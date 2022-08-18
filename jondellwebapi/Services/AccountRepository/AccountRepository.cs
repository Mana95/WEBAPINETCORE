using AutoMapper;
using jondellwebapi.Dtos.Balance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Data;
using webapi.Models;

namespace jondellwebapi.Services.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public AccountRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public Task<ServiceResponse<List<Balance>>> GetAllBalance()
        {
            throw new NotImplementedException();
        }

    


        public Task<ServiceResponse<List<Balance>>> GetBalanceByDateRange()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<string>> SaveBalanceSheet(List<AddBalanceDto> newBalance)
        {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();
            //    Account account = new 
               // var balanceList = (newBalance.Select(c => _mapper.Map<AddBalanceDto>(c))).ToList();
                foreach(var itm in newBalance)
            {
                Balance balance = _mapper.Map<Balance>(itm);
             //   var accout = await _context.Account.FirstOrDefault(c => c.id == itm.AccountId);

                await _context.Balance.AddAsync(balance);
                await _context.SaveChangesAsync();
            }
           
              
        }

        
    }
}
