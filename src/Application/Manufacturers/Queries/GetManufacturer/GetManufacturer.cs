using BestFootForwardApi.Application.Common.Interfaces;
using BestFootForwardApi.Application.Manufacturers.Common;

namespace BestFootForwardApi.Application.Manufacturers.Queries.GetManufacturer;

public record GetManufacturerQuery : IRequest<ManufacturerBaseDto>
{
}

public class GetManufacturerQueryValidator : AbstractValidator<GetManufacturerQuery>
{
    public GetManufacturerQueryValidator()
    {
    }
}

public class GetManufacturerQueryHandler : IRequestHandler<GetManufacturerQuery, ManufacturerBaseDto>
{
    private readonly IApplicationDbContext _context;

    public GetManufacturerQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ManufacturerBaseDto> Handle(GetManufacturerQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
