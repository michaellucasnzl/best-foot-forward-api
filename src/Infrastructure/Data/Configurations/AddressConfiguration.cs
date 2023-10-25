using BestFootForwardApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestFootForwardApi.Infrastructure.Data.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(t => t.Address1).HasMaxLength(100).IsRequired();
        builder.Property(t => t.Address2).HasMaxLength(100);
        builder.Property(t => t.Suburb).HasMaxLength(50);
        builder.Property(t => t.City).HasMaxLength(50).IsRequired();
        builder.Property(t => t.PostCode).HasMaxLength(10).IsRequired();
        builder.Property(t => t.Country).HasMaxLength(50).IsRequired().HasDefaultValue("New Zealand");
    }
}
