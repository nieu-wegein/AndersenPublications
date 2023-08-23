using Pub.Domain;

namespace Pub.Api.Contracts.Responses
{
	public record AuthorResponse(
		Guid Id,
		string FirstName,
		string LastName,
		List<Publication>? Publications);
}
