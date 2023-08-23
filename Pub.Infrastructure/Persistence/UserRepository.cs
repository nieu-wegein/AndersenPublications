using Microsoft.EntityFrameworkCore;
using Pub.Application.Interfaces.Authorisation;
using Pub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
	{
		private readonly PubDbContext _dbContext;

		public UserRepository(PubDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<User>> GetAllAsync()
		{
			return await _dbContext.Users.ToListAsync();
		}

		public async Task<User?> GetByIdAsync(Guid id)
		{
			return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
		}

		public async Task<User?> GetByEmailAsync(string email)
		{
			return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
		}

		public async Task<bool> AddAsync(User user)
		{
			await _dbContext.AddAsync(user);
			await _dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<bool> UpdateAsync(User user)
		{
			var dbUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

			if (dbUser == null)
				return false;

			dbUser.FirstName = user.FirstName;
			dbUser.LastName = user.LastName;
			dbUser.Email = user.Email;
			dbUser.Password = user.Password;

			await _dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

			if (user == null)
				return false;

			_dbContext.Users.Remove(user);
			await _dbContext.SaveChangesAsync();

			return true;
		}
	}
}
