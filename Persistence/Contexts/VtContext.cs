using System;
using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
	public class VtContext : DbContext
	{
		protected IConfiguration Configuration { get; set; }
		public DbSet<Brand> MyProperty { get; set; }
		public DbSet<Fuel> Fuels { get; set; }
		public DbSet<Car> Cars { get; set; }
		public DbSet<Model> Models { get; set; }
		public DbSet<Transmission> Transmissions { get; set; }

		public VtContext(DbContextOptions<VtContext> options,IConfiguration configuration):base(options)
		{
			Configuration = configuration;
			Database.EnsureCreated();//db nin oluştuğundan emin ol
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

