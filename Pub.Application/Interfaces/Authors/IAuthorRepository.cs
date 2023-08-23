using Pub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Application.Interfaces.Authors
{
	public interface IAuthorRepository
	{
		Task<IEnumerable<Author>> GetAllAsync();
		Task<Author?> GetAsync(Guid id);
		Task<bool> AddAsync(Author author);
		Task<bool> UpdateAsync(Author author);
		Task<bool> DeleteAsync(Guid id);
	}
}
