using Microsoft.AspNetCore.Authentication;
using Pub.Api.Contracts.Requests.Authentication;
using Pub.Api.Contracts.Responses;
using Pub.Application.Services.Authentication;
using Pub.Domain;

namespace Pub.Api.Extensions
{
	public static class AuthenticationDTOExtensions
	{
		public static User ToUser(this RegistrationRequest request)
		{
			var user = new User
			{
				Id = Guid.NewGuid(),
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				Password = request.Password
			};

			return user;
		}

		public static AuthenticationResponse ToAuthenticationResponse(this AuthenticationResult result)
		{
			var response = new AuthenticationResponse(
				Username: result.User.Email,
				Acces_token: result.Token);

			return response;
		}
	}
}
