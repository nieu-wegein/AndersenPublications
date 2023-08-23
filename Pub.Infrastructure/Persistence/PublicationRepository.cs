using Microsoft.EntityFrameworkCore;
using Pub.Application.Interfaces.Publications;
using Pub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Infrastructure.Persistence
{
    public class PublicationRepository : IPublicationRepository
	{
		private readonly PubDbContext _dbContext;

		public PublicationRepository(PubDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Publication>> GetAllAsync()
		{
			return await _dbContext.Publications.ToListAsync();
		}
		public async Task<Publication?> GetAsync(Guid id)
		{
			return await _dbContext.Publications.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<bool> AddAsync(Publication publication)
		{
			await _dbContext.Publications.AddAsync(publication);
			await _dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<bool> UpdateAsync(Publication publication)
		{
			var pub = await _dbContext.Publications.FirstOrDefaultAsync(p => p.Id == publication.Id);

			if (pub == null)
				return false;

			pub.Title = publication.Title;
			pub.Field = publication.Field;
			pub.Url = publication.Url;

			await _dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var pub = await _dbContext.Publications.FirstOrDefaultAsync(p => p.Id == id);
			
			if (pub == null)
				return false;

			_dbContext.Publications.Remove(pub);
			await _dbContext.SaveChangesAsync();

			return true;
		}
	}
}
