using AutoMapper;
using jondellwebapi.Dtos.Balance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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
        public async Task<ServiceResponse<List<GetBalanceDto>>> GetBalanceByDateRange(string fromDate, string toDate)
        {
            ServiceResponse<List<GetBalanceDto>> serviceResponse = new ServiceResponse<List<GetBalanceDto>>();
            try
            {
                DateTime _toDate = DateTime.ParseExact(toDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime _fromDate = DateTime.ParseExact(fromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var _getResponse = _context.Balance.Where(s =>   _fromDate <= s.date  && s.date <= _toDate);
                var _mapBalanceList = (_getResponse.Select(c => _mapper.Map<GetBalanceDto>(c))).ToList(); ;
                serviceResponse.Data = GetFilterBalanceData(_mapBalanceList);
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.ToString();
                serviceResponse.success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBalanceDto>>> GetAllBalance()
        {
            ServiceResponse<List<GetBalanceDto>> serviceResponse = new ServiceResponse<List<GetBalanceDto>>();
            try
            {
                var _mapDto = (_context.Balance.Select(c => _mapper.Map<GetBalanceDto>(c)).ToList());
                serviceResponse.Data = GetFilterBalanceData(_mapDto);
            }
            catch(Exception ex)
            {
                serviceResponse.Message = ex.ToString();
                serviceResponse.success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<string>> SaveBalanceSheet(List<AddBalanceDto> newBalance)
        {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();
            try
            {
                foreach (var itm in newBalance)
                {
                    Balance balance = _mapper.Map<Balance>(itm);
                    balance.account = _context.Account.FirstOrDefault(c => c.id == itm.accountId);

                    await _context.Balance.AddAsync(balance);
                    await _context.SaveChangesAsync();

                }
            }
            catch(Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.Message = ex.ToString();
            }
                return serviceResponse;
        }


        //filter data
        private List<GetBalanceDto> GetFilterBalanceData(List<GetBalanceDto> balanceList )
        {
            var _balanceList = new List<Balance>();
            var _accountList = _context.Account.Select(x => x).ToList();
            foreach (var account in _accountList)
            {
                var _filterBalance = balanceList.Where(b => b.accountId == account.id).ToList();
                if (_filterBalance != null)
                {
                    Balance Newbalance = new Balance();
                    Newbalance.balance = 0;
                    foreach (var balance in _filterBalance)
                    {
                        
                        Newbalance.balance = Newbalance.balance + balance.balance;
                    }
                    Newbalance.accountId = account.id;
                    _balanceList.Add(Newbalance);
                }
            }
            var _mapBalance = _balanceList.Select(c => _mapper.Map<GetBalanceDto>(c)).ToList();

            return _mapBalance;
        }
        
    }
}
