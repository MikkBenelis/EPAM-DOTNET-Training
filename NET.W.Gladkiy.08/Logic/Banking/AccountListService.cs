namespace Logic.BankingSystem
{
    using System;
    using System.IO;

    public static class AccountListService
    {
        /// <summary>Add account to database</summary>
        /// <param name="als">this account storage</param>
        /// <param name="account">account to add</param>
        public static void AddAccount(this AccountListStorage als, Account account)
        {
            if (account == null || als.Database.Contains(account))
            {
                throw new ArgumentException();
            }

            als.Database.Add(account);
        }

        /// <summary>Remove account from database</summary>
        /// <param name="als">this account storage</param>
        /// <param name="account">account to remove</param>
        public static void RemoveAccount(this AccountListStorage als, int accountID)
        {
            bool wasRemoved = false;
            foreach (Account account in als.Database)
            {
                if (account.AccountID == accountID)
                {
                    wasRemoved = true;
                    als.Database.Remove(account);
                    break;
                }
            }

            if (!wasRemoved)
            {
                throw new ArgumentException();
            }
        }

        /// <summary>Print database to stream</summary>
        /// <param name="bls">this account storage</param>
        /// <param name="tw">output textwritter stream</param>
        public static void PrintLibrary(this AccountListStorage als, TextWriter tw)
        {
            if (tw == null)
            {
                throw new ArgumentException();
            }

            foreach (Account account in als.Database)
            {
                tw.WriteLine(account);
            }
        }
    }
}
