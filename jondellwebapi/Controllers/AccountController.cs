using AutoMapper;
using jondellwebapi.Dtos.Balance;
using jondellwebapi.Services.AccountRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace jondellwebapi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IAccountRepository  _accRepo;
       
        public AccountController(IAccountRepository accRepo)
        {
           _accRepo = accRepo;
          
        }

        [HttpPost("saveaccount")]
        public async Task<IActionResult> AddBalanceSheet(List<AddBalanceDto> newBalance)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            response = await _accRepo.SaveBalanceSheet(newBalance);
            return Ok(response);
           
           // DateTimeTo

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var serviceResponse = await _accRepo.GetAllBalance();
            return Ok(serviceResponse);
        }

        [HttpPost("post")]
        public async Task<IActionResult> GetByDateBalance(Balance balance)
        {
            var serviceResponse = await _accRepo.GetBalanceByDateRange(balance.date);
            return Ok("");
        }
    }
}
