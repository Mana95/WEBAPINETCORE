using AutoMapper;
using jondellwebapi.Dtos.Balance;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using webapi.Data;
using webapi.Models;
using Xunit;

namespace johndellwebapitests.Services
{
    public class AccountRepositoryTests
    {

        public AccountRepositoryTests()
        {
            SaveAccountTypeToMock();
        }

        [Fact]
        public void GetByDateRange()
        {
            var mockDbMemory = new MockDbMemory();
            var _accountRepo = mockDbMemory.GetInMemoryAccountRepository();
            var balance = SaveInformationSheet();
            var getBalanceList = _accountRepo.GetBalanceByDateRange("2022-06-23", "2022-06-25").GetAwaiter().GetResult();
            //Assert.NotNull(getBalanceList);
            foreach (var blnce in getBalanceList.Data)
            {
                var singleVal = balance.First(s => s.accountId == blnce.accountId).accountId;
                Assert.Equal(blnce.accountId, singleVal);
            }
        }

        [Fact]
        public void SaveAccountInformation()
        {
            var mockDbMemory = new MockDbMemory();
            // Repositories with InMemory Database
            var _accountRepo = mockDbMemory.GetInMemoryAccountRepository();
            // use Write Repository to add mock data
            //var balance = new List<AddBalanceDto>();
            List<AddBalanceDto> balance = new List<AddBalanceDto>();
            balance.Add(new AddBalanceDto
            {
                accountId = "1",
                date = DateTime.ParseExact("2022-05-23", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                balance = 2.3
            });

            // use Write Repository to add mock data
            var saveBalance = _accountRepo.SaveBalanceSheet(balance).GetAwaiter().GetResult();
            Assert.True(saveBalance.success);
        }

        [Fact]
        public void GetAllBalance()
        {
            var mockDbMemory = new MockDbMemory();
            // Repositories with InMemory Database
            var _accountRepo = mockDbMemory.GetInMemoryAccountRepository();
            // use Write Repository to add mock data
            // 
            var balance = SaveInformationSheet();

            // use Specification in Read Repository and get data
            var getBalanceList = _accountRepo.GetAllBalance().GetAwaiter().GetResult();
            Assert.NotNull(getBalanceList);
            foreach (var blnce in getBalanceList.Data)
            {
                var singleVal = balance.First(s => s.accountId == blnce.accountId).accountId;
                Assert.Equal(blnce.accountId, singleVal);
            }
        }

        //Save account details
        private void SaveAccountTypeToMock()
        {
            var mockDbMemory = new MockDbMemory();
            var context = mockDbMemory.GetDBContext();

            var accountList = new List<Account>
            {
                {  new Account{id="1" ,accountType="R&D"}},
                {  new Account{id="2" ,accountType="Canteen"} },
                {  new Account{id="3" ,accountType="CEO's car"} },
                {  new Account{id="4" ,accountType="Marketing"} },
                {  new Account{id="5" ,accountType="Parking fines"} }
            };

            foreach (var acc in accountList)
            {
                context.Account.AddAsync(acc);
                context.SaveChanges();

            }
            
        }


        private List<AddBalanceDto> SaveInformationSheet()
        {
            var mockDbMemory = new MockDbMemory();
            // Repositories with InMemory Database
            var _accountRepo = mockDbMemory.GetInMemoryAccountRepository();

            var balance = new List<AddBalanceDto>
             {
                new AddBalanceDto {
                    accountId = "1", balance = 250 , date =DateTime.ParseExact("2022-05-23", "yyyy-MM-dd", CultureInfo.InvariantCulture)

             }
            };
            _accountRepo.SaveBalanceSheet(balance).GetAwaiter();

            return balance;
        }

    }
}
