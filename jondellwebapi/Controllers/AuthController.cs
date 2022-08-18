using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Dtos.User;
using webapi.Models;
using webapi.Services.AuthRepository;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authrepo)
        {
            this._authRepo = authrepo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegistrationDto request)
        {
            ServiceResponse<int> response = await _authRepo.Register(
                new User { Username = request.Username }, request.Password , request.Role
                );
            if (!response.success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            ServiceResponse<string> response = await _authRepo.Login(
                 request.Username , request.Password
                );
            if (!response.success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
