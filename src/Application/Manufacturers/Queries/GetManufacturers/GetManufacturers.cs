using BestFootForwardApi.Application.Common.Interfaces;

namespace BestFootForwardApi.Application.Manufacturers.Queries.GetManufacturers;

public record GetManufacturersQuery : IRequest<ManufacturersDto>
{
}

public class ManufacturersDto
{
}

public class GetManufacturersQueryValidator : AbstractValidator<GetManufacturersQuery>
{
    public GetManufacturersQueryValidator()
    {
    }
}

public class GetManufacturersQueryHandler : IRequestHandler<GetManufacturersQuery, ManufacturersDto>
{
    private readonly IApplicationDbContext _context;

    public GetManufacturersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ManufacturersDto> Handle(GetManufacturersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
