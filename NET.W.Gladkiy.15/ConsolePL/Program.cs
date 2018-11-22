// * Разработать систему типов для описания работы с банковским счетом.
// Состояние счета определяется его номером, данными о владельце счета
// (имя, фамилия), суммой на счете и некоторыми бонусными баллами, которые
// увеличиваются/уменьшаются каждый раз при пополнении счета/списании со
// счета на величины различные для пополнения и списания и рассчитываемые
// в зависимости от некоторых значений величин «стоимости» баланса и «стоимости»
// пополнения.Величины «стоимости» баланса и «стоимости» пополнения являются
// целочисленными значениями и зависят от типа счета, который может быть,
// например, Base, Gold, Platinum.
// Для работы со счетом реализовать следующие возможности:
//   * выполнить пополнение на счет;
//   * выполнить списание со счета;
//   * создать новый счет;
//   * закрыть счет.
// Для хранения информации о счетах можно использовать fake-имплементацию 
// репозитория в виде класса-обертки для коллекции List<Account>.
// Работу классов продемонстрировать на примере консольного приложения.
// При проектировании типов учитывать следующие возможности 
// расширения/изменения функциональности:
//   * добавление новых видов счетов;
//   * изменение/добавление источников хранения информации о счетах;
//   * изменение логики расчета бонусных баллов;
//   * изменении логики генерации номера счета.
// Для организации классов и интерфейсов использовать "The Stairway pattern".
// Для разрешения зависимостей использовать Ninject-фреймворк.
// Протестировать слой Bll (NUnit и Moq фреймворки).

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
