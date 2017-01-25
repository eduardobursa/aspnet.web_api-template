using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Template.WebApi.Startup))]

namespace Template.WebApi
{
	/// <summary>
	/// Defines an entry point for the application configuration.
	/// </summary>
	public partial class Startup
	{
		/// <summary>
		/// Configures the application.
		/// </summary>
		/// <remarks>
		/// For more information on how to configure 
		/// your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
		/// </remarks>
		/// <param name="app">The application.</param>
		public void Configuration(IAppBuilder app)
		{
			var config = GlobalConfiguration.Configuration;

			ConfigureOAuth(app);
			ConfigureSwagger(config);
			ConfigureWebApi(config);

			app.UseCors(CorsOptions.AllowAll);
			app.UseWebApi(config);

			config.EnsureInitialized();
		}
	}
}
