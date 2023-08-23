using Microsoft.Extensions.DependencyInjection;
using Pub.Application.Interfaces.Authorisation;
using Pub.Application.Interfaces.Authors;
using Pub.Application.Interfaces.Publications;
using Pub.Application.Services.Authentication;
using Pub.Application.Services.Authors;
using Pub.Application.Services.Publications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Application
{
    public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddScoped<IAuthenticationService, AuthenticationService>();
			services.AddScoped<IPublicationService, PublicationService>();
			services.AddScoped<IAuthorService, AuthorService>();

			return services;
		}
	}
}
