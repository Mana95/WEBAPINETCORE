using AutoMapper;
using jondellwebapi.Services.AccountRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using webapi;
using webapi.Data;
using webapi.Services.AuthRepository;

namespace johndellwebapitests
{
    class MockDbMemory
    {
        private readonly DataContext testDbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration _config;
        public MockDbMemory()
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseInMemoryDatabase(databaseName: "johndellDbInMemory");
            var dbContextOptions = builder.Options;
            testDbContext = new DataContext(dbContextOptions);
            // Delete existing db before creating a new one
            testDbContext.Database.EnsureDeleted();
            testDbContext.Database.EnsureCreated();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile()); 
            });

            this._config= new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        }
      
        public DataContext GetDBContext()
        {
            return testDbContext;
        }

        public IAccountRepository GetInMemoryAccountRepository()
        {
            return new AccountRepository(testDbContext , mapper);
        }
        public IAuthRepository GetInMemoryAuthRepository()
        {
            return new AuthRepository(testDbContext, _config);
        }

    }

    

}

