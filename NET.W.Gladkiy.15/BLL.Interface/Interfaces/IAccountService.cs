namespace BLL.Interface.Interfaces
{
    using System.Collections.Generic;
    using BLL.Interface.Entities;

    public interface IAccountService
    {
        IEnumerable<Account> GetAllAccounts();

        void Create(Account account);

        void Remove(int accountID);

        void Deposit(int accountID, decimal amount);

        void Withdraw(int accountID, decimal amount);
    }
}
