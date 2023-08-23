using Pub.Domain;

namespace Pub.Application.Services.Authentication
{
	public record AuthenticationResult(
		User User,
		string Token);
}