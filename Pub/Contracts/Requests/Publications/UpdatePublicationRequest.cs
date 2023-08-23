using Pub.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pub.Api.Contracts.Requests.Publications
{
    public record UpdatePublicationRequest(
		[Required]
		[MaxLength(150)]
		string Title,

		[Required]
		Field Field,

		[Required]
		[Url]
		string Url);
}
