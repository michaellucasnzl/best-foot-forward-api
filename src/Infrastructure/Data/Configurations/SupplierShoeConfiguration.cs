using BestFootForwardApi.Domain.Entities;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestFootForwardApi.Infrastructure.Data.Configurations;

public class SupplierShoeConfiguration : IEntityTypeConfiguration<SupplierShoe>
{
    public void Configure(EntityTypeBuilder<SupplierShoe> builder)
    {
        builder.Property(_ => _.WholesalePrice).IsRequired().HasColumnType(Strings.PriceColumnType);
        builder.HasOne<Supplier>(_ => _.Supplier).WithMany(_ => _.SupplierShoes);
        builder.HasOne<Shoe>(_ => _.Shoe).WithMany(_ => _.SupplierShoes);

    }
}
