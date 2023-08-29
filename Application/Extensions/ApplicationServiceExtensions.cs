using System;
using System.Reflection;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{

			services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));
			services.AddMediatR(config =>
			{
				config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                config.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
                config.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			return services;
		}

        public static IServiceCollection AddSubClassesOfType(
       this IServiceCollection services,
       Assembly assembly,
       Type type,
       Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
   )
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();//subclass olanları IoC ye ekle
            foreach (var item in types)
                if (addWithLifeCycle == null)
                    services.AddScoped(item);

                else
                    addWithLifeCycle(services, type);
            return services;
        }
    }
}

