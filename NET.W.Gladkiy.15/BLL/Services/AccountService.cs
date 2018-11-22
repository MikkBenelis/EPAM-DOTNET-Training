namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;
    using BLL.Mappers;
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;

    public class AccountService : IAccountService
    {
        private IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            if (repository != null)
            {
                _repository = repository;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            foreach (AccountDTO account in _repository.GetAllAccounts())
            {
                yield return AccountMapper.MapAccountFromDTO(account);
            }
        }

        public void Create(Account account)
        {
            if (account != null)
            {
                _repository.Create(AccountMapper.MapAccountToDTO(account));
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void Remove(int accountID)
        {
            _repository.Remove(accountID);
        }

        public void Deposit(int accountID, decimal amount)
        {
            foreach (AccountDTO accountDTO in _repository.GetAllAccounts())
            {
                Account account = AccountMapper.MapAccountFromDTO(accountDTO);
                if (account.AccountID == accountID)
                {
                    switch (account.Type)
                    {
                        case AccountType.BASE:
                            amount *= 1.05M;
                            break;

                        case AccountType.GOLD:
                            amount *= 1.10M;
                            break;

                        case AccountType.PLATINUM:
                            amount *= 1.25M;
                            break;
                    }

                    break;
                }
            }

            _repository.Deposit(accountID, amount);
        }

        public void Withdraw(int accountID, decimal amount)
        {
            _repository.Withdraw(accountID, amount);
        }
    }
}
