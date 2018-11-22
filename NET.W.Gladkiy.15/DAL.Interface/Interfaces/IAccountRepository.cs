namespace DAL.Interface.Interfaces
{
    using System.Collections.Generic;
    using DAL.Interface.DTO;

    public interface IAccountRepository
    {
        int Count { get; }

        IEnumerable<AccountDTO> GetAllAccounts();

        void Create(AccountDTO account);

        void Remove(int accountID);

        void Deposit(int accountID, decimal amount);

        void Withdraw(int accountID, decimal amount);
    }
}
