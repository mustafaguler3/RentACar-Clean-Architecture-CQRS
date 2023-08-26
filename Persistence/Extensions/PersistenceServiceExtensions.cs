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

            /*services.AddDbContext<VtContext>(opt =>
			{
				opt.UseInMemoryDatabase("nArchitecture");
			});*/
            services.AddDbContext<VtContext>(opt =>
            {
				opt.UseSqlite(configuration.GetConnectionString("Local"));
            });
            services.AddScoped<IBrandRepository, BrandRepository>();

            services.AddScoped<IModelRepository, ModelRepository>();
            return services;

		}
	}
}

