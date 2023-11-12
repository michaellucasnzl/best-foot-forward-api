using BestFootForwardApi.Application.Manufacturers.Common;
using BestFootForwardApi.Domain.Entities;

namespace BestFootForwardApi.Application.Manufacturers.Queries.GetManufacturer;

public class GetManufacturerDto : ManufacturerBaseDto
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Manufacturer, GetManufacturerDto>();
        }
    }
}