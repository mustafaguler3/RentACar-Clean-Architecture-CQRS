using System;
using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence.Extensions
{
	public static class PersistenceServiceExtensions
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddDbContext<VtContext>(opt =>
			{
				opt.UseInMemoryDatabase("nArchitecture");
			});
			services.AddScoped<IBrandRepository, BrandRepository>();

			return services;
		}
	}
}

