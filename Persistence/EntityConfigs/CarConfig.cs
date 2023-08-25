using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigs
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars").HasKey(i => i.Id);
            builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
            builder.Property(i => i.ModelId).HasColumnName("ModelId").IsRequired();
            builder.Property(i => i.Kilometer).HasColumnName("Kilometer").IsRequired();
            builder.Property(i => i.CarState).HasColumnName("State").IsRequired();
            builder.Property(i => i.ModelYear).HasColumnName("ModelYear").IsRequired();

            builder.HasOne(b => b.Model);

            builder.HasQueryFilter(i => !i.DeletedDate.HasValue);//! yoksa,her query ye uygula

        }
    }
}

