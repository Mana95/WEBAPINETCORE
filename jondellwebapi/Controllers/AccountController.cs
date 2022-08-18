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
           


        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllBalance()
        {
            return Ok("");
        }

        [HttpGet("getByDate")]
        public async Task<IActionResult> GetByDateBalance()
        {
            return Ok("");
        }
    }
}
