using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Services.AuthRepository
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password, string Role);
        Task<ServiceResponse<string>> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}
