using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Pub.Application.Interfaces.Authorisation;
using Pub.Application.Interfaces.Authors;
using Pub.Application.Interfaces.Publications;
using Pub.Infrastructure.Authentication;
using Pub.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Infrastructure
{
    public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddDbContext<PubDbContext>(options => options.UseSqlServer());
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IPublicationRepository, PublicationRepository>();
			services.AddScoped<IAuthorRepository, AuthorRepository>();
			services.AddSingleton<ITokenGenerator, TokenGenerator>();

			return services;
		}

	}
}
