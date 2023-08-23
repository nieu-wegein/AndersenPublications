using Pub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Application.Interfaces.Publications
{
    public interface IPublicationRepository
    {
		Task<IEnumerable<Publication>> GetAllAsync();
        Task<Publication?> GetAsync(Guid id);
        Task<bool> AddAsync(Publication publication);
        Task<bool> UpdateAsync(Publication publication);
        Task<bool> DeleteAsync(Guid id);
    }
}
