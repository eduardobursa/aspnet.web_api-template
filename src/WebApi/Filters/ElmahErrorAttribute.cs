using System.Web.Http.Filters;

namespace Template.WebApi.Filters
{
	/// <summary>
	/// Defines an exception filter for logging errors on elmah.
	/// </summary>
	public class ElmahErrorAttribute : ExceptionFilterAttribute
	{
		/// <summary>
		/// Raises the exception event.
		/// </summary>
		/// <param name="actionExecutedContext">The context for the action.</param>
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			if (actionExecutedContext.Exception != null)
				Elmah.ErrorSignal.FromCurrentContext().Raise(actionExecutedContext.Exception);

			base.OnException(actionExecutedContext);
		}
	}
}