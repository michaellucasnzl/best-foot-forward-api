using BestFootForwardApi.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection.Manufacturers.Common;

namespace BestFootForwardApi.Application.Manufacturers.Queries.GetManufacturer;

public record GetManufacturerQuery : IRequest<ManufacturerDto>
{
}

public class GetManufacturerQueryValidator : AbstractValidator<GetManufacturerQuery>
{
    public GetManufacturerQueryValidator()
    {
    }
}

public class GetManufacturerQueryHandler : IRequestHandler<GetManufacturerQuery, ManufacturerDto>
{
    private readonly IApplicationDbContext _context;

    public GetManufacturerQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ManufacturerDto> Handle(GetManufacturerQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
