using System.ComponentModel.DataAnnotations;

namespace Pub.Api.Contracts.Requests.Authentication
{
    public record RegistrationRequest(
		[Required]
		[MinLength(2)] 
        string FirstName,

		[Required]
		[MinLength(2)] 
        string LastName,

		[Required]
		[EmailAddress]
        string Email,

		[Required]
		[MinLength(8)]
		string Password);
}
