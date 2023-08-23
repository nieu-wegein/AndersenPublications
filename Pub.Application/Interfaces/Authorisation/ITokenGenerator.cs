using Pub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Application.Interfaces.Authorisation
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
