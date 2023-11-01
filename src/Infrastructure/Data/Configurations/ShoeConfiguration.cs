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
        builder.Property(t => t.Colour).IsRequired().HasConversion(c => c.ToString(), s => Colour.From(s));
        builder.Property(t => t.Size).IsRequired();
        builder.Property(t => t.Description).HasMaxLength(500);
        builder.Property(t => t.ImageUrl).HasMaxLength(200);
        builder.HasOne<Manufacturer>(s => s.Manufacturer).WithMany(m => m.Shoes);
        builder.HasMany(s => s.ShopShoes).WithOne(s => s.Shoe);
        builder.HasMany(s => s.SupplierShoes).WithOne(s => s.Shoe);
    }
}
