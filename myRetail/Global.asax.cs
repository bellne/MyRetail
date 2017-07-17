using CompositionRoot;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace myRetail
{
	public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

	        // Dependency Injection
	        var container = DependencyConfig.RegisterDependencies();
	        // For MVC Controllers
	        DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
	        // For Web API Controllers
	        GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

	        // Make sure API routes are configured before MVC routes
	        GlobalConfiguration.Configure(WebApiConfig.Register);
	        RouteConfig.RegisterRoutes(RouteTable.Routes);
		}
    }
}
