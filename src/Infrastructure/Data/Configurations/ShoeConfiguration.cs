using BestFootForwardApi.Domain.Entities;
using BestFootForwardApi.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestFootForwardApi.Infrastructure.Data.Configurations;

public class ShoeConfiguration : IEntityTypeConfiguration<Shoe>
{
    public void Configure(EntityTypeBuilder<Shoe> builder)
    {
        builder.Property(t => t.Name).HasMaxLength(200).IsRequired();
        builder.Property(t => t.Colour).IsRequired().HasConversion(_ => _.ToString(), _ => Colour.From(_));
        builder.Property(t => t.Size).IsRequired();
        builder.Property(t => t.Description).HasMaxLength(500);
        builder.Property(t => t.ImageUrl).HasMaxLength(200);
        builder.HasOne<Manufacturer>(_ => _.Manufacturer).WithMany(_ => _.Shoes);
        builder.HasMany(_ => _.ShopShoes).WithOne(_ => _.Shoe);
        builder.HasMany(_ => _.SupplierShoes).WithOne(_ => _.Shoe);
    }
}
