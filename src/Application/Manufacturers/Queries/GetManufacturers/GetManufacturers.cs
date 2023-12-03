using BestFootForwardApi.Application.Common.Interfaces;
using BestFootForwardApi.Application.Common.Mappings;
using BestFootForwardApi.Application.Common.Models;

namespace BestFootForwardApi.Application.Manufacturers.Queries.GetManufacturers;

public record GetManufacturersQuery : SearchQuery, IRequest<PaginatedList<ManufacturerListItem>>
{
    
}

public class GetManufacturersQueryValidator : AbstractValidator<GetManufacturersQuery>
{
    public GetManufacturersQueryValidator()
    {
    }
}

public class GetManufacturersQueryHandler : IRequestHandler<GetManufacturersQuery, PaginatedList<ManufacturerListItem>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetManufacturersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ManufacturerListItem>> Handle(GetManufacturersQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Manufacturers.AsNoTracking()
            .ProjectTo<ManufacturerListItem>(_mapper.ConfigurationProvider)
            .OrderBy(x => x.Name)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        
        return result;
    }
}