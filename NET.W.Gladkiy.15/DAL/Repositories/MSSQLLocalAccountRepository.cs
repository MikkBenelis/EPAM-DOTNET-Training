namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using DAL.Interface.DTO;
    using DAL.Interface.Interfaces;
    
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
                try
                {
                    var account = (from a in context.Accounts
                                   where a.AccountID == accountID
                                   select a).Single();
                    context.Accounts.Remove(account);
                    context.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                    // Ignore
                }
            }
        }

        public void Deposit(int accountID, decimal amount)
        {
            using (var context = new AccountsContext())
            {
                try
                {
                    var account = (from a in context.Accounts
                                   where a.AccountID == accountID
                                   select a).Single();
                    account.Balance += amount;
                    context.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                    // Ignore
                }
            }
        }

        public void Withdraw(int accountID, decimal amount)
        {
            using (var context = new AccountsContext())
            {
                try
                {
                    var account = (from a in context.Accounts
                                   where a.AccountID == accountID
                                   select a).Single();
                    account.Balance -= amount;
                    context.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                    // Ignore
                }
            }
        }

        public class AccountsContext : DbContext
        {
            public DbSet<AccountDTO> Accounts { get; set; }
        }
    }
}
