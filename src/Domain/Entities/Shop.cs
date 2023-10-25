namespace BestFootForwardApi.Domain.Entities;

public class Shop : BaseAuditableEntity<Guid>
{
    public required string Name { get; set; }
    
    public Address? Address { get; set; }
    public ICollection<ShopShoe>? ShopShoes { get; set; }
}
