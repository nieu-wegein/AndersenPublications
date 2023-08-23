using System.ComponentModel.DataAnnotations;

namespace Pub.Api.Contracts.Requests.Authors
{
	public record AddAuthorRequest(
		[Required]
		[MinLength(2)]
		string FirstName,

		[Required]
		[MinLength(2)]
		string LastName);
}
