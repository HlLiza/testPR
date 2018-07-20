using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using RentalHousingService.BLL.DI;
using RentalHousingService.WEB.App_Start;
using RentalHousingService.WEB.DI;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RentalHousingService.WEB
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperWebConfiguration.Configure();

            NinjectModule orderModule = new WebModule();
            NinjectModule serviceModule = new ServiceModule(ConfigurationManager.ConnectionStrings["RentalContext"].ToString());
            var kernel = new StandardKernel(orderModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

        }
    }
}
