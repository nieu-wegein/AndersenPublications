using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pub.Api.Contracts.Requests.Authentication;
using Pub.Api.Extensions;
using Pub.Application.Interfaces.Authorisation;

namespace Pub.Controllers
{
    [Route("auth")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthenticationService _authService;
		public AuthenticationController(IAuthenticationService authService)
		{
			_authService = authService;
		}

		[HttpPost("/register")]
		public async Task<IActionResult> Register(RegistrationRequest request)
		{
			var user = request.ToUser();
			var authResult = await _authService.Register(user);
			var response = authResult.ToAuthenticationResponse();

			return new JsonResult(response);
		}

		[HttpPost("/login")]
		public async Task<IActionResult> Login(LoginRequest req)
		{
			var authResult = await _authService.Login(req.Email, req.Password);
			var response = authResult.ToAuthenticationResponse();

			return new JsonResult(response);
		}
	}
}
