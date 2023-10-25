using BestFootForwardApi.Application.Common.Interfaces;
using BestFootForwardApi.Application.Shoes.Common.Dtos;
using BestFootForwardApi.Domain.Entities;

namespace BestFootForwardApi.Application.Shoes.Queries.GetShoesByManufacturer;

public record GetShoesByManufacturerQuery : IRequest<List<ShoeDto>>
{
    public Guid ManufacturerId { get; set; }
}

public class GetShoesByManufacturerQueryValidator : AbstractValidator<GetShoesByManufacturerQuery>
{
    public GetShoesByManufacturerQueryValidator()
    {
        RuleFor(_ => _.ManufacturerId).NotNull();
    }
}

public class GetShoesByManufacturerQueryHandler : IRequestHandler<GetShoesByManufacturerQuery, List<ShoeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetShoesByManufacturerQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ShoeDto>> Handle(GetShoesByManufacturerQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Shoes.AsNoTracking()
            .Where(_ => _.ManufacturerId.Equals(request.ManufacturerId))
            .ProjectTo<ShoeDto>(_mapper.ConfigurationProvider)
            .OrderBy(_ => _.Name)
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}
