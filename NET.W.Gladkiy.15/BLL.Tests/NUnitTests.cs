namespace BLL.Tests
{
    using System.Collections.Generic;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;
    using BLL.Mappers;
    using BLL.Services;
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class NUnitTests
    {
        private Mock<IAccountRepository> mock;

        [SetUp]
        public void TestSetup()
        {
            var accounts = new List<AccountDTO>
            {
                new AccountDTO { Balance = 100, FirstName = "A", LastName = "A", Type = AccountTypeDTO.BASE },
                new AccountDTO { Balance = 100, FirstName = "B", LastName = "B", Type = AccountTypeDTO.GOLD },
                new AccountDTO { Balance = 100, FirstName = "C", LastName = "C", Type = AccountTypeDTO.PLATINUM }
            };

            mock = new Mock<IAccountRepository>();
            mock.Setup(x => x.GetAllAccounts()).Returns(accounts);
            mock.Setup(x => x.Count).Returns(accounts.Count);

            // TODO
        }

        [Test]
        public void CreateAccountTest()
        {
            IAccountRepository accountRepository = mock.Object;
            IAccountService accountService = new AccountService(accountRepository);
            
            // TODO
        }

        [Test]
        public void AccountMapperFromDTOTest()
        {
            AccountDTO accountDTO = new AccountDTO
            {
                AccountID = 1,
                Balance = 100,
                FirstName = "FName1",
                LastName = "LName1",
                Type = AccountTypeDTO.BASE
            };

            Account account = AccountMapper.MapAccountFromDTO(accountDTO);
            Assert.That(account.ToString(), Is.EqualTo(accountDTO.ToString()));
        }

        [Test]
        public void AccountMapperToDTOTest()
        {
            Account account = new Account
            {
                AccountID = 1,
                Balance = 100,
                FirstName = "FName1",
                LastName = "LName1",
                Type = AccountType.BASE
            };

            AccountDTO accountDTO = AccountMapper.MapAccountToDTO(account);
            Assert.That(accountDTO.ToString(), Is.EqualTo(account.ToString()));
        }

        [Test]
        public void AccoutTypeMapperFromDTOTest()
        {
            AccountTypeDTO accountTypeDTO = AccountTypeDTO.BASE;
            AccountType accountType = AccountTypeMapper.MapAccountTypeFromDTO(accountTypeDTO);
            Assert.That(accountTypeDTO.ToString(), Is.EqualTo(accountType.ToString()));
        }

        [Test]
        public void AccoutTypeMapperToDTOTest()
        {
            AccountType accountType = AccountType.BASE;
            AccountTypeDTO accountTypeDTO = AccountTypeMapper.MapAccountTypeToDTO(accountType);
            Assert.That(accountType.ToString(), Is.EqualTo(accountTypeDTO.ToString()));
        }
    }
}
