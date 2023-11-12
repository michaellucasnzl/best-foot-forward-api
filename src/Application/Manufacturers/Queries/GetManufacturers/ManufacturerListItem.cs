namespace BestFootForwardApi.Application.Manufacturers.Queries.GetManufacturers;

public class ManufacturerListItem
{
    public required string Name { get; set; }
    public int ShoeCount { get; set; }
    public required string Country { get; set; }
}