using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigs
{
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands").HasKey(i => i.Id);
            builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
            builder.Property(i => i.Name).HasColumnName("Name").IsRequired();
            builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate").IsRequired();
            builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate").IsRequired();

            builder.HasQueryFilter(i => !i.DeletedDate.HasValue);//! yoksa,her query ye uygula

        }
    }
}

