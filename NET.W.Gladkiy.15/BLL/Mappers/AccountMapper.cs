namespace BLL.Mappers
{
    using System;
    using BLL.Interface.Entities;
    using DAL.Interface.DTO;

    public static class AccountMapper
    {
        public static Account MapAccountFromDTO(AccountDTO accountDTO)
        {
            if (accountDTO != null)
            {
                return new Account
                {
                    AccountID = accountDTO.AccountID,
                    Balance = accountDTO.Balance,
                    FirstName = accountDTO.FirstName,
                    LastName = accountDTO.LastName,
                    Type = AccountTypeMapper.MapAccountTypeFromDTO(accountDTO.Type)
                };
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public static AccountDTO MapAccountToDTO(Account account)
        {
            if (account != null)
            {
                return new AccountDTO
                {
                    AccountID = account.AccountID,
                    Balance = account.Balance,
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Type = AccountTypeMapper.MapAccountTypeToDTO(account.Type)
                };
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
