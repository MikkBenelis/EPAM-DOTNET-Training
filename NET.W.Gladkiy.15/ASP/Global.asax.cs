using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DependencyResolver;
using Ninject;

namespace ASP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static readonly IKernel Resolver;

        static MvcApplication()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigureResolver();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
