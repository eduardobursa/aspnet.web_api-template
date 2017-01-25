using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace Template.WebApi.Authorization
{
	/// <summary>
	/// Implements an OAuthAuthorizationServerProvider.
	/// </summary>
	/// <seealso cref="OAuthAuthorizationServerProvider" />
	public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
	{
		/// <summary>
		/// Called to validate that the origin of the request is a registered "client_id", and that the correct credentials for that client are
		/// present on the request. If the web application accepts Basic authentication credentials,
		/// context.TryGetBasicCredentials(out clientId, out clientSecret) may be called to acquire those values if present in the request header. If the web
		/// application accepts "client_id" and "client_secret" as form encoded POST parameters,
		/// context.TryGetFormCredentials(out clientId, out clientSecret) may be called to acquire those values if present in the request body.
		/// If context.Validated is not called the request will not proceed further.
		/// </summary>
		/// <param name="context">The context of the event carries information in and results out.</param>
		/// <returns>
		/// Task to enable asynchronous execution
		/// </returns>
		public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			context.Validated();
		}

		/// <summary>
		/// Grants the resource owner credentials.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns>
		/// Task to enable asynchronous execution
		/// </returns>
		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

			// TODO: add real authentication logic here
			if (context.UserName != "admin" || context.Password != "admin")
			{
				context.SetError("invalid_grant", "The user name or password is incorrect.");
				return;
			}

			var identity = new ClaimsIdentity(new GenericIdentity(context.UserName, OAuthDefaults.AuthenticationType));
			identity.AddClaim(new Claim("sub", context.UserName));
			identity.AddClaim(new Claim("role", "user"));

			context.Validated(identity);

			var authentication = HttpContext.Current.GetOwinContext().Authentication;
			authentication.SignIn(new AuthenticationProperties { IsPersistent = true }, identity);
		}
	}
}