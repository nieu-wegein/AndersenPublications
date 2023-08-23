using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Pub.Api.Extensions
{
	public static class AddAuthExtension
	{
		public static IServiceCollection AddAuth(this IServiceCollection services)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidIssuer = "PublicationApi",
				ValidateAudience = true,
				ValidAudience = "PublicationApi",
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("random-secret-key"))
			});

			return services;
		}
	}
}
