using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using webapi.Models;
using Xunit;

namespace johndellwebapitests.Services
{
    public class AuthRepositoryTests
    {

        private IConfiguration configuration;

        MockDbMemory mockDbMemory = new MockDbMemory();


        [Fact]
        public void Login()
        {
            var _authRepo = mockDbMemory.GetInMemoryAuthRepository();
            User user = new User
            {
                Username = "john",
                Role = ""
            };
            var registerUser = _authRepo.Register(user, "123456", "Admin").GetAwaiter().GetResult();
            var loginUser = _authRepo.Login("john" , "123456").GetAwaiter().GetResult();

            Assert.Equal(registerUser.success, loginUser.success);
        }

        [Fact]
        public void Register()
        {
            var _authRepo = mockDbMemory.GetInMemoryAuthRepository();
            User user = new User
            {
                Username ="john"
            };
            var registerUser = _authRepo.Register(user, "123456", "Admin").GetAwaiter().GetResult();

           Assert.True(registerUser.success);
        }

        [Fact]
        public void InCorrectCredential()
        {
            var _authRepo = mockDbMemory.GetInMemoryAuthRepository();
            User user = new User
            {
                Username = "john",
                Role = "Admin"
            };
            var expectedPassword = false;
            var actualPassword = "1111111";
            _authRepo.Register(user, "123456", "Admin").GetAwaiter().GetResult();
            var loginUser = _authRepo.Login("john", actualPassword).GetAwaiter().GetResult();

            Assert.Equal(expectedPassword, loginUser.success);
        }


    }
}
