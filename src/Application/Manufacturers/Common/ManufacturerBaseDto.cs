using BestFootForwardApi.Application.Common.Models;
using BestFootForwardApi.Domain.Entities;

namespace BestFootForwardApi.Application.Manufacturers.Common;

public class ManufacturerBaseDto
{
    public Guid? Id { get; set; }
    public required string Name { get; set; }
    public AddressDto? Address { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Manufacturer, ManufacturerBaseDto>();
        }
    }
}