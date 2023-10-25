using BestFootForwardApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestFootForwardApi.Infrastructure.Data.Configurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.Property(t => t.Name).HasMaxLength(200).IsRequired();
        builder.HasOne<Address>(_ => _.Address);
        builder.HasMany(_ => _.SupplierShoes).WithOne(_ => _.Supplier);

    }
}
