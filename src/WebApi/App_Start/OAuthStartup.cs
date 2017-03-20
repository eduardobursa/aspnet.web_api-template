using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using EduardoBursa.Templates.WebApi.Authorization;
using System;

namespace EduardoBursa.Templates.WebApi
{
	/// <summary>
	/// Defines an entry point for the oauth configuration.
	/// </summary>
	public partial class Startup
	{
		/// <summary>
		/// Configures the oAuth.
		/// </summary>
		/// <param name="app">The application.</param>
		public void ConfigureOAuth(IAppBuilder app)
		{
			OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/oauth/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
				Provider = new AuthorizationServerProvider()
			};

			// Token Generation
			app.UseOAuthAuthorizationServer(OAuthServerOptions);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
		}
	}
}
