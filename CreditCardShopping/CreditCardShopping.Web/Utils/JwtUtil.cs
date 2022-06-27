using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace CreditCardShopping.Web.Utils
{
	public class JwtUtil
	{
		public async Task<string> GetToken(HttpContext context)
		{
			var token = await context.GetTokenAsync("access_token");
			return token;
		}

		public void Authorize(HttpClient client, string token)
		{
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}
	}
}
