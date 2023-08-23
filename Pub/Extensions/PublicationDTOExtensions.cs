using Pub.Api.Contracts.Requests.Publications;
using Pub.Api.Contracts.Responses;
using Pub.Domain;

namespace Pub.Api.Extensions
{
    public static class PublicationDTOExtensions
	{
		public static Publication ToPublication(this CreatePublicationRequest request)
		{
			var publication = new Publication
			{
				Id = Guid.NewGuid(),
				Title = request.Title,
				Field = request.Field,
				Url = request.Url,
				PublicationDate = DateTime.Now,
				AuthorId = request.AuthorId,
				UserId = request.UserId,
			};

			return publication;
		}

		public static Publication ToPublication(this UpdatePublicationRequest request, Guid id)
		{
			var publication = new Publication
			{
				Id = id,
				Title = request.Title,
				Field = request.Field,
				Url = request.Url
			};

			return publication;
		}

		public static PublicationResponse ToPublicationResponse(this Publication publication)
		{
			var pub = new PublicationResponse(
				Id: publication.Id,
				Title: publication.Title,
				Url: publication.Url,
				PublicationDate: publication.PublicationDate,
				Field: publication.Field,
				AuthorId: publication.AuthorId,
				UserId: publication.UserId);

			return pub;
		}

	}
}