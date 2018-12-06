namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;
    
    public class AccountsContext : DbContext
    {
        public DbSet<AccountDTO> Accounts { get; set; }
    }
    
    public class MSSQLLocalAccountRepository : IAccountRepository
    {
        public int Count
        {
            get
            {
                using (var context = new AccountsContext())
                {
                    return (from a in context.Accounts
                           select a).Count();
                }
            }
        }

        public IEnumerable<AccountDTO> GetAllAccounts()
        {
            using (var context = new AccountsContext())
            {
                return (from a in context.Accounts select a).ToList();
            }
        }
        
        public void Create(AccountDTO account)
        {
            using (var context = new AccountsContext())
            {
                context.Accounts.Add(account);
                context.SaveChanges();
            }
        }

        public void Remove(int accountID)
        {
            using (var context = new AccountsContext())
            {
                var account = (from a in context.Accounts
                               where a.AccountID == accountID
                               select a).Single();
                context.Accounts.Remove(account);
                context.SaveChanges();
            }
        }

        public void Deposit(int accountID, decimal amount)
        {
            using (var context = new AccountsContext())
            {
                var account = (from a in context.Accounts
                               where a.AccountID == accountID
                               select a).Single();
                account.Balance += amount;
                context.SaveChanges();
            }
        }

        public void Withdraw(int accountID, decimal amount)
        {
            using (var context = new AccountsContext())
            {
                var account = (from a in context.Accounts
                               where a.AccountID == accountID
                               select a).Single();
                account.Balance -= amount;
                context.SaveChanges();
            }
        }
    }
}
