using BestFootForwardApi.Domain.Entities;

namespace BestFootForwardApi.Application.Manufacturers.Queries.GetManufacturers;

public class ManufacturerListItem
{
    public required string Name { get; set; }
    public int ShoeCount { get; set; }
    public required string Country { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Manufacturer, ManufacturerListItem>()
                .ForMember(d => d.ShoeCount, e =>
                    e.MapFrom(s => s.Shoes != null ? s.Shoes.Count : 0));
        }
    }
}