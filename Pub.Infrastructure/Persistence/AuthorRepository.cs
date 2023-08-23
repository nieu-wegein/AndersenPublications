using Microsoft.EntityFrameworkCore;
using Pub.Application.Interfaces.Authors;
using Pub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Infrastructure.Persistence
{
	public class AuthorRepository : IAuthorRepository
	{
		private readonly PubDbContext _dbContext;
		public AuthorRepository(PubDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Author>> GetAllAsync()
		{
			return await _dbContext.Authors.ToListAsync();
		}

		public async Task<Author?> GetAsync(Guid id)
		{
			return await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);	
		}

		public async Task<bool> AddAsync(Author author)
		{
			await _dbContext.Authors.AddAsync(author);
			await _dbContext.SaveChangesAsync();
			return true;
		}
		public async Task<bool> UpdateAsync(Author author)
		{
			var auth = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == author.Id);

			if (auth == null)
				return false;

			auth.FirstName = author.FirstName;
			auth.LastName = author.LastName;

			await _dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var author = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);

			if(author == null)
				return false;

			_dbContext.Authors.Remove(author);
			await _dbContext.SaveChangesAsync();

			return true;
		}
	}
}
