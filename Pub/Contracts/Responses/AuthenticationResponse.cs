using Azure.Core;

namespace Pub.Api.Contracts.Responses
{
	public record AuthenticationResponse(
		string Acces_token,
		string Username);
	
}
