using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigs
{
    public class ModelConfig : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Models").HasKey(i => i.Id);
            builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
            builder.Property(i => i.Name).HasColumnName("Name").IsRequired();
            builder.Property(i => i.BrandId).HasColumnName("BrandId").IsRequired();
            builder.Property(i => i.FuelId).HasColumnName("FuelId").IsRequired();
            builder.Property(i => i.TransmissionId).HasColumnName("TransmissionId").IsRequired();
            builder.Property(i => i.DailyPrice).HasColumnName("DailyPrice").IsRequired();
            builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate").IsRequired();
            builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate").IsRequired();

            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Model_Name").IsUnique();
            builder.HasOne(b => b.Brand);
            builder.HasOne(b => b.Fuel);
            builder.HasOne(b => b.Transmission);

            builder.HasMany(b => b.Cars);
            builder.HasQueryFilter(i => !i.DeletedDate.HasValue);//! yoksa,her query ye uygula

        }
    }
}

