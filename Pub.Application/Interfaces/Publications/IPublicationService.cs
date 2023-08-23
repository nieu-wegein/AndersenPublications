using Pub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Application.Interfaces.Publications
{
    public interface IPublicationService
    {
		Task<IEnumerable<Publication>> GetAll();
        Task<Publication> Get(Guid id);
        Task Add(Publication publication);
        Task Update(Publication publication);
        Task Delete(Guid id);
    }
}
