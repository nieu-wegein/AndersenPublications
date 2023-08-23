using Pub.Application.Exceptions;
using Pub.Application.Interfaces.Authorisation;
using Pub.Application.Interfaces.Publications;
using Pub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Application.Services.Publications
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
		public PublicationService(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

		public async Task<IEnumerable<Publication>> GetAll()
		{
			var publications = await _publicationRepository.GetAllAsync();
			return publications;
		}

		public async Task<Publication> Get(Guid id)
		{
			var publication = await _publicationRepository.GetAsync(id);

			if(publication == null)
				throw new PublicationNotFoundException();

			return publication;
		}

		public async Task Add(Publication publication)
        {

			await _publicationRepository.AddAsync(publication);
		}

		public async Task Update(Publication publication)
		{
			bool isUpdated = await _publicationRepository.UpdateAsync(publication);

			if (!isUpdated)
				throw new PublicationNotFoundException();
		}

		public async Task Delete(Guid id)
        {
			bool isDeleted = await _publicationRepository.DeleteAsync(id);

			if (!isDeleted)
				throw new PublicationNotFoundException();
		}
    }
}
