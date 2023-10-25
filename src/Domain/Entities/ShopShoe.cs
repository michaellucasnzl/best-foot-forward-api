namespace BestFootForwardApi.Domain.Entities;

public class ShopShoe : BaseAuditableEntity<Guid>
{
    public required Guid ShopId { get; set; }
    public required Guid ShoeId { get; set; }
    public required decimal RetailPrice { get; set; }

    public Shop? Shop { get; set; }
    public Shoe? Shoe { get; set; }
}
