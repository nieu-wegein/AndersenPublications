using Pub.Application.Exceptions;
using Pub.Application.Interfaces.Authorisation;
using Pub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
	{
		private readonly ITokenGenerator _tokenGenerator;
		private readonly IUserRepository _userRepository;

		public AuthenticationService(ITokenGenerator tokenGenerator, IUserRepository userRepository)
		{
			_tokenGenerator = tokenGenerator;
			_userRepository = userRepository;
		}

		public async Task<AuthenticationResult> Login(string email, string password)
		{
			if (await _userRepository.GetByEmailAsync(email) is not User user)
				throw new EmailExistsException();

			if (user.Password != password)
				throw new IncorrectPasswordException();


			var token = _tokenGenerator.GenerateToken(user);

			return new AuthenticationResult(user, token);
		}

		public async Task<AuthenticationResult> Register(User user)
		{
			if (await _userRepository.GetByEmailAsync(user.Email) != null)
				throw new EmailExistsException(); 

			await _userRepository.AddAsync(user);
			var token = _tokenGenerator.GenerateToken(user);

			return new AuthenticationResult(user, token);
		}
	}
}
