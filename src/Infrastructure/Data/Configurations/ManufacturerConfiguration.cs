using BestFootForwardApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestFootForwardApi.Infrastructure.Data.Configurations;

public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.Property(t => t.Name).HasMaxLength(200).IsRequired();
        builder.HasOne<Address>(_ => _.Address);
        builder.HasMany(_ => _.Shoes).WithOne(_ => _.Manufacturer);
    }
}
