using Pub.Application.Exceptions;
using Pub.Application.Interfaces.Authors;
using Pub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Application.Services.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

		public async Task<IEnumerable<Author>> GetAll()
		{
			var authors = await _authorRepository.GetAllAsync();
            return authors;
		}

		public async Task<Author> Get(Guid id)
		{
			var author = await _authorRepository.GetAsync(id);

			if (author == null)
				throw new AuthorNotFoundException(); 

			return author;
		}

		public async Task Add(Author author)
        {
			await _authorRepository.AddAsync(author);
		}

		public async Task Update(Author author)
		{
			bool isUpdated = await _authorRepository.UpdateAsync(author);

			if (!isUpdated)
				throw new AuthorNotFoundException();
		}

		public async Task Delete(Guid id)
        {
			bool isDeleted = await _authorRepository.DeleteAsync(id);

			if (!isDeleted)
				throw new AuthorNotFoundException();
		}
    }
}
