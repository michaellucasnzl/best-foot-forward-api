using BestFootForwardApi.Application.Common.Interfaces;

namespace BestFootForwardApi.Application.Manufacturers.Queries.GetManufacturers;

public record GetManufacturersQuery : IRequest<GetManufacturersDto>
{
}

public class GetManufacturersQueryValidator : AbstractValidator<GetManufacturersQuery>
{
    public GetManufacturersQueryValidator()
    {
    }
}

public class GetManufacturersQueryHandler : IRequestHandler<GetManufacturersQuery, GetManufacturersDto>
{
    private readonly IApplicationDbContext _context;

    public GetManufacturersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GetManufacturersDto> Handle(GetManufacturersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
