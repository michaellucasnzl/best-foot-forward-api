using BestFootForwardApi.Domain.Entities;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestFootForwardApi.Infrastructure.Data.Configurations;

public class ShopShoeConfiguration : IEntityTypeConfiguration<ShopShoe>
{
    public void Configure(EntityTypeBuilder<ShopShoe> builder)
    {
        builder.Property(s => s.RetailPrice).IsRequired().HasColumnType(Strings.PriceColumnType);
        builder.HasOne<Shop>(s => s.Shop).WithMany(s => s.ShopShoes);
        builder.HasOne<Shoe>(s => s.Shoe).WithMany(s => s.ShopShoes);

    }
}
