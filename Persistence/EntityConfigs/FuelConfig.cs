using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigs
{
    public class FuelConfig : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            builder.ToTable("Fuels").HasKey(i => i.Id);
            builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
            builder.Property(i => i.Name).HasColumnName("Name").IsRequired();
            builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate").IsRequired();
            builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate").IsRequired();

            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Fuels_Name").IsUnique();
            builder.HasMany(b => b.Models);

            builder.HasQueryFilter(i => !i.DeletedDate.HasValue);//! yoksa,her query ye uygula

        }
    }
}

