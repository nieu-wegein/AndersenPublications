using Pub.Api.Contracts.Requests.Authors;
using Pub.Api.Contracts.Responses;
using Pub.Domain;

namespace Pub.Api.Extensions
{
	public static class AuthorDTOExtensions
	{
		public static AuthorResponse ToAuthorResponse(this Author author)
		{
			var auth = new AuthorResponse(
				Id: author.Id,
				FirstName: author.FirstName,
				LastName: author.LastName,
				Publications: author.Publications);

			return auth;
		}

		public static Author ToAuthor(this AddAuthorRequest request)
		{

			var author = new Author
			{
				Id = Guid.NewGuid(),
				FirstName = request.FirstName,
				LastName = request.LastName
			};

			return author;
		}

		public static Author ToAuthor(this UpdateAuthorRequest request, Guid id)
		{

			var author = new Author
			{
				Id = id,
				FirstName = request.FirstName,
				LastName = request.LastName
			};

			return author;
		}
	}
}
