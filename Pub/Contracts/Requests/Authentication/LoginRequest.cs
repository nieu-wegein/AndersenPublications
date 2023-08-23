using System.ComponentModel.DataAnnotations;

namespace Pub.Api.Contracts.Requests.Authentication
{
    public record LoginRequest(
		[Required]
		[EmailAddress]
		string Email,

		[Required]
		[MinLength(8)]
		string Password);
}
