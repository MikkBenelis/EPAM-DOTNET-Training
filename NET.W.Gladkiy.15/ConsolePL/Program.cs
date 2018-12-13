namespace ConsoleUI
{
    using System;
    using System.Linq;
    using BLL.Interface.Entities;
    using BLL.Interface.Interfaces;
    using DependencyResolver;
    using Ninject;

    public sealed class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigureResolver();
        }

        public static void Main(string[] args)
        {
            IAccountService service = Resolver.Get<IAccountService>();

            service.Create(new Account { FirstName = "FirstName1", LastName = "LastName1", Type = AccountType.BASE });
            service.Create(new Account { FirstName = "FirstName2", LastName = "LastName2", Type = AccountType.GOLD });
            service.Create(new Account { FirstName = "FirstName3", LastName = "LastName3", Type = AccountType.PLATINUM });

            var accounts = service.GetAllAccounts().ToArray();

            foreach (var account in accounts)
            {
                service.Deposit(account.AccountID, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            foreach (var account in accounts)
            {
                service.Withdraw(account.AccountID, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }
        }
    }
}
