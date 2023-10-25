namespace BestFootForwardApi.Domain.Entities;

public class Manufacturer : BaseAuditableEntity<Guid>
{
    public required string Name { get; set; }
    
    public Address? Address { get; set; }
    public ICollection<Shoe>? Shoes { get; set; }
}
