using Microsoft.IdentityModel.Tokens;
using Pub.Application.Interfaces.Authorisation;
using Pub.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Infrastructure.Authentication
{
    public class TokenGenerator : ITokenGenerator
	{
		public string GenerateToken(User user)
		{
			var signingCredentials = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes("random-secret-key")),
				SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, user.FirstName)
			};

			var token = new JwtSecurityToken(
				issuer: "PublicationApi",
				audience: "PublicationApi",
				expires: DateTime.Now.AddDays(1),
				claims: claims,
				signingCredentials: signingCredentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
