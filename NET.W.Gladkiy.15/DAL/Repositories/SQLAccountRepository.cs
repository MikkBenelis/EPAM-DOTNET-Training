namespace DAL.Repositories
{
    using System.Collections.Generic;
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;

    public class SQLAccountRepository : IAccountRepository
    {
        public int Count { get => throw new System.NotImplementedException(); }

        public IEnumerable<AccountDTO> GetAllAccounts()
        {
            throw new System.NotImplementedException();
        }

        public void Create(AccountDTO account)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int accountID)
        {
            throw new System.NotImplementedException();
        }

        public void Deposit(int accountID, decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public void Withdraw(int accountID, decimal amount)
        {
            throw new System.NotImplementedException();
        }
    }
}
