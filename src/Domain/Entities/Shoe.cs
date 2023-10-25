namespace BestFootForwardApi.Domain.Entities;

public class Shoe : BaseAuditableEntity<Guid>
{
    public required string Name { get; set; }
    public required int Size { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public required Colour Colour { get; set; }
    public required Guid ManufacturerId { get; set; }

    public Manufacturer? Manufacturer { get; set; }
    public ICollection<ShopShoe>? ShopShoes { get; set; }
    public ICollection<SupplierShoe>? SupplierShoes { get; set; }
}
