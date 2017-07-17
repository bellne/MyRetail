using Newtonsoft.Json;
using Swashbuckle.Application;
using System.Web.Http;

namespace myRetail
{
	public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

	        config.EnableCors();
	        config.EnableSwagger(s =>
	        {
		        s.SingleApiVersion("v1", "Product API");
	        }).EnableSwaggerUi();
	        config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

			config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

	        config.EnsureInitialized();
        }
	}
}
