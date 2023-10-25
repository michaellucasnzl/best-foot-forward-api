namespace BestFootForwardApi.Domain.Entities;

public class SupplierShoe: BaseAuditableEntity<Guid>
{
    public required Guid SupplierId { get; set; }
    public required Guid ShoeId { get; set; }
    public required decimal WholesalePrice { get; set; }
    
    public Supplier? Supplier { get; set; }
    public Shoe? Shoe { get; set; }
}