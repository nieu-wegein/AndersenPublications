using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pub.Api.Contracts.Requests.Authors;
using Pub.Api.Extensions;
using Pub.Application.Interfaces.Authors;

namespace Pub.Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{

		private readonly IAuthorService _authorService;

		public AuthorsController(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAuthors()
		{
			var authors = await _authorService.GetAll();
			var response = authors.Select(a => a.ToAuthorResponse()).ToList();

			return Ok(response);
		}

		[HttpGet("{id:guid}")]
		public async Task<IActionResult> GetAuthor(Guid id)
		{
			var author = await _authorService.Get(id);
			var response = author.ToAuthorResponse();

			return Ok(response);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> AddAuthor(AddAuthorRequest request)
		{
			var author = request.ToAuthor();
			await _authorService.Add(author);

			return CreatedAtAction(
				actionName: nameof(GetAuthor), 
				routeValues: new { id = author.Id },
				value: author.ToAuthorResponse());
		}

		[HttpPut("{id:guid}")]
		[Authorize]
		public async Task<IActionResult> UpdateAuthor(Guid id, UpdateAuthorRequest request)
		{
			var author = request.ToAuthor(id);
			await _authorService.Update(author);

			return NoContent();
		}

		[HttpDelete("{id:guid}")]
		[Authorize]
		public async Task<IActionResult> DeleteAuthor(Guid id)
		{
			await _authorService.Delete(id);

			return NoContent();
		}
	}
}
