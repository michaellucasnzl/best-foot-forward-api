using BestFootForwardApi.Application.Manufacturers.Common;
using BestFootForwardApi.Application.Shoes.Common.Dtos;
using BestFootForwardApi.Domain.Entities;

namespace BestFootForwardApi.Application.Manufacturers.Queries.GetManufacturer;

public class GetManufacturerDto : ManufacturerBaseDto
{
    public List<ShoeDto> Shoes { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Manufacturer, GetManufacturerDto>()
                .ForMember(d => d.Shoes, e =>
                    e.MapFrom(s => s.Shoes));
        }
    }
}