using BestFootForwardApi.Domain.Entities;

namespace BestFootForwardApi.Application.Shoes.Common.Dtos;

public class ShoeDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required int Size { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public required string ColourCode { get; set; }
    public required Guid ManufacturerId { get; set; }
    public required string ManufacturerName { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Shoe, ShoeDto>()
                .ForMember(d => d.ColourCode, e => e.MapFrom(s => s.Colour.ToString()))
                .ForMember(d => d.ManufacturerName, e => e.MapFrom(s => s.Manufacturer!.Name));
        }
    }
}
