namespace DAL.Repositories
{
    using System.Collections.Generic;
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;

    public class FakeAccountRepository : IAccountRepository
    {
        private static List<AccountDTO> accounts = new List<AccountDTO>();

        public int Count { get => accounts.Count; }

        public IEnumerable<AccountDTO> GetAllAccounts()
        {
            return accounts;
        }

        public void Create(AccountDTO account)
        {
            if (!accounts.Contains(account))
            {
                account.AccountID = accounts.Count;
                accounts.Add(account);
            }
        }

        public void Remove(int accountID)
        {
            foreach (AccountDTO account in accounts)
            {
                if (account.AccountID == accountID)
                {
                    accounts.Remove(account);
                    break;
                }
            }
        }

        public void Deposit(int accountID, decimal amount)
        {
            foreach (AccountDTO account in accounts)
            {
                if (account.AccountID == accountID)
                {
                    account.Balance += amount;
                }
            }
        }

        public void Withdraw(int accountID, decimal amount)
        {
            foreach (AccountDTO account in accounts)
            {
                if (account.AccountID == accountID)
                {
                    account.Balance -= amount;
                }
            }
        }
    }
}
