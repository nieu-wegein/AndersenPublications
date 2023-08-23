using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pub.Api.Contracts.Requests.Publications;
using Pub.Api.Extensions;
using Pub.Application.Interfaces.Publications;
using Pub.Domain;
using System;
using System.Security.Claims;

namespace Pub.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PublicationsController : ControllerBase
	{
		private readonly IPublicationService _publicationService;

		public PublicationsController(IPublicationService publicationService)
		{
			_publicationService = publicationService;
		}


		[HttpGet]
		public async Task<IActionResult> GetAllPublications()
		{
			var publications = await _publicationService.GetAll();
			var response = publications.Select(p => p.ToPublicationResponse()).ToList();

			return Ok(response);
		}

		[HttpGet("{id:guid}")]
		public async Task<IActionResult> GetPublication(Guid id)
		{
			var publication = await _publicationService.Get(id);
			var response = publication.ToPublicationResponse();

			return Ok(response);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> CreatePublication(CreatePublicationRequest request)
		{

			var publication = request.ToPublication();
			await _publicationService.Add(publication);

			return CreatedAtAction(
				actionName: nameof(GetPublication),
				routeValues: new { id = publication.Id },
				value: publication.ToPublicationResponse());
		}

		[HttpPut("{id:guid}")]
		[Authorize]
		public async Task<IActionResult> UpdatePublication(Guid id, UpdatePublicationRequest request)
		{
			var publication = request.ToPublication(id);
			await _publicationService.Update(publication);

			return NoContent();
		}

		[HttpDelete("{id:guid}")]
		[Authorize]
		public async Task<IActionResult> DeletePublication(Guid id)
		{
			await _publicationService.Delete(id);

			return NoContent();
		}
	}
}
