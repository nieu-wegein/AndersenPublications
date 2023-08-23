using Pub.Domain.Enums;

namespace Pub.Api.Contracts.Responses
{
	public record PublicationResponse(
		Guid Id,
		string Title,
		Field Field,
		string Url,
		DateTime PublicationDate,
		Guid AuthorId,
		Guid UserId);
}
