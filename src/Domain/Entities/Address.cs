namespace BestFootForwardApi.Domain.Entities;

public class Address: BaseAuditableEntity<Guid>
{
    public required string Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? Suburb { get; set; }
    public required string PostCode { get; set; }
    public required string City { get; set; }
    public string? Country { get; set; }
}
