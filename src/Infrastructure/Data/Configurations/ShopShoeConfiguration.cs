using BestFootForwardApi.Domain.Entities;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestFootForwardApi.Infrastructure.Data.Configurations;

public class ShopShoeConfiguration : IEntityTypeConfiguration<ShopShoe>
{
    public void Configure(EntityTypeBuilder<ShopShoe> builder)
    {
        builder.Property(_ => _.RetailPrice).IsRequired().HasColumnType(Strings.PriceColumnType);
        builder.HasOne<Shop>(_ => _.Shop).WithMany(_ => _.ShopShoes);
        builder.HasOne<Shoe>(_ => _.Shoe).WithMany(_ => _.ShopShoes);

    }
}
