using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;
using EduardoBursa.Templates.WebApi.Filters;

namespace EduardoBursa.Templates.WebApi
{
	/// <summary>
	/// Defines an entry point for web api configuration.
	/// </summary>
	public partial class Startup
	{
		/// <summary>
		/// Configures the web API.
		/// </summary>
		/// <param name="config">The configuration.</param>
		public void ConfigureWebApi(HttpConfiguration config)
		{
			config.Filters.Add(new AuthorizeAttribute());
			config.Filters.Add(new ElmahErrorAttribute());

			var corsAttr = new EnableCorsAttribute("*", "*", "*");
			config.EnableCors(corsAttr);

			// map web api route prefix
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

			config.Formatters.Remove(config.Formatters.XmlFormatter);
		}
	}
}
