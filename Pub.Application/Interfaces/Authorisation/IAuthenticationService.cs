using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pub.Application.Services.Authentication;
using Pub.Domain;

namespace Pub.Application.Interfaces.Authorisation
{
    public interface IAuthenticationService
    {

		Task<AuthenticationResult> Login(string email, string password);
		Task<AuthenticationResult> Register(User user);
    }
}
