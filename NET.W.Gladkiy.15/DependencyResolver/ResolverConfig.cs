using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Services;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigureResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IAccountRepository>().To<MSSQLLocalAccountRepository>();
        }
    }
}
