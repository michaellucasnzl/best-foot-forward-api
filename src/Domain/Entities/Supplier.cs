namespace BestFootForwardApi.Domain.Entities;

public class Supplier : BaseAuditableEntity<Guid>
{
    public required string Name { get; set; }

    public Address? Address { get; set; }
    public ICollection<SupplierShoe>? SupplierShoes { get; set; }
}
