using BestFootForwardApi.Domain.Entities;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestFootForwardApi.Infrastructure.Data.Configurations;

public class SupplierShoeConfiguration : IEntityTypeConfiguration<SupplierShoe>
{
    public void Configure(EntityTypeBuilder<SupplierShoe> builder)
    {
        builder.Property(s => s.WholesalePrice).IsRequired().HasColumnType(Strings.PriceColumnType);
        builder.HasOne<Supplier>(s => s.Supplier).WithMany(s => s.SupplierShoes);
        builder.HasOne<Shoe>(s => s.Shoe).WithMany(s => s.SupplierShoes);

    }
}
