using System.Web.Http;

namespace EduardoBursa.Templates.WebApi.Controllers
{
	/// <summary>
	/// Defines a controller for tests.
	/// </summary>
	[RoutePrefix("api/tests")]
	public class TestsController : ApiController
	{
		/// <summary>
		/// Gets an simple response from the api.
		/// </summary>
		/// <remarks>
		///  You must receive an "Ok" as response if everithing is fine.																
		/// </remarks>
		/// <returns>
		/// string
		/// </returns>
		[HttpGet, Route()]
		public string Get()
		{
			return "Ok";
		}

		/// <summary>
		/// Force an api error to test elmah error handling.
		/// </summary>
		/// <remarks>
		/// A call to this resource will cause an application error
		/// that will be logged using elmah. To verify logged errors check 
		/// access localhost:port/elmah.axd
		/// </remarks>
		/// <returns>
		/// int
		/// </returns>
		[HttpGet, Route("error")]
		public int Error()
		{
			int a = 0,
					b = 10;

			return b / a;
		}
	}
}
