using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using System.Drawing.Text;

namespace EndPoint.Admin.Utilities
{
	public static class CurrentUser
	{
		public static string Get()
		{
			HttpContextAccessor httpContextAccessor = new();

			var username = httpContextAccessor.HttpContext.Session.GetString("ActiveUser");
			return username;
		}
		public static void Set(ActiveUser activeUser)
		{
			
			HttpContextAccessor httpContextAccessor = new();
			httpContextAccessor.HttpContext.Session.SetString("ActiveUser", activeUser.UserId);
			return;

		}
	}
}
