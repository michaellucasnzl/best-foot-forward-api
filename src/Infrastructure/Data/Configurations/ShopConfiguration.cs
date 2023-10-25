using BestFootForwardApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestFootForwardApi.Infrastructure.Data.Configurations;

public class ShopConfiguration : IEntityTypeConfiguration<Shop>
{
    public void Configure(EntityTypeBuilder<Shop> builder)
    {
        builder.Property(t => t.Name).HasMaxLength(200).IsRequired();
        builder.HasOne<Address>(_ => _.Address);
        builder.HasMany(_ => _.ShopShoes).WithOne(_ => _.Shop);
    }
}
