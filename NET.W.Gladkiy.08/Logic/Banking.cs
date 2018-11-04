namespace BankingSystem
{
    using System;
    using System.Collections.Generic;
    using Logic.BankingSystem;

    public class Program
    {
        public static void Main(string[] args)
        {
            var bank = new AccountListStorage();

            // Try to load database
            if (bank.LoadFromDisk("database.dat"))
            {
                Console.WriteLine("Database loaded from disk!");
            }
            else
            {
                // Fill database
                bank.AddAccount(new Account("name1", "surname1", Account.EType.BASE));
                bank.AddAccount(new Account("name2", "surname2", Account.EType.GOLD));
                bank.AddAccount(new Account("name3", "surname3", Account.EType.PLATINUM));

                Console.WriteLine("Created account database:");
            }
            
            if (bank.IsEmpty)
            {
                Console.WriteLine("Database is empty!");
            }
            else
            {
                bank.PrintLibrary(Console.Out);
            }

            Console.WriteLine();
            
            // Add balance to all accounts
            foreach (Account account in bank.Database)
            {
                account.AddBalance(500);
            }

            Console.WriteLine("After adding balance:");
            if (bank.IsEmpty)
            {
                Console.WriteLine("Database is empty!");
            }
            else
            {
                bank.PrintLibrary(Console.Out);
            }

            Console.WriteLine();

            // Withdraw from all accounts
            foreach (Account account in bank.Database)
            {
                account.Withdraw(500);
            }

            Console.WriteLine("After withdrawing:");
            if (bank.IsEmpty)
            {
                Console.WriteLine("Database is empty!");
            }
            else
            {
                bank.PrintLibrary(Console.Out);
            }

            Console.WriteLine();

            // Try to save database
            if (bank.SaveToDisk("database.dat"))
            {
                Console.WriteLine("Database saved to disk!");
            }
            else
            {
                Console.WriteLine("Can't save database!");
            }

            Console.WriteLine();
        }
    }
}
