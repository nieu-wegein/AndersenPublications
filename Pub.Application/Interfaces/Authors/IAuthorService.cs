using Pub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Application.Interfaces.Authors
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author> Get(Guid id);
        Task Add(Author author);
		Task Update(Author author);
		Task Delete(Guid id);
    }
}
