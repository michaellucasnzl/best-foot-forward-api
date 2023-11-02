using BestFootForwardApi.Application.Common.Models;
using BestFootForwardApi.Application.Manufacturers.Queries.GetManufacturer;

namespace BestFootForwardApi.Application.Manufacturers.Queries.GetManufacturers;

public class GetManufacturersDto
{
    public GetManufacturersDto(PaginatedList<GetManufacturerDto> manufacturers)
    {
        Manufacturers = manufacturers;
    }

    public PaginatedList<GetManufacturerDto> Manufacturers { get; set; } 
    
}