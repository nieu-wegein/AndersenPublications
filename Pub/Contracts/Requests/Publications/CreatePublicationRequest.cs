using Pub.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pub.Api.Contracts.Requests.Publications
{
    public record CreatePublicationRequest(
		[Required]
		[MaxLength(150)]
		string Title,

		[Required]
		[Url]
		string Url,

		[Required]
		Field Field,

        Guid AuthorId,
        Guid UserId);
}
