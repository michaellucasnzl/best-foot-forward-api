using BestFootForwardApi.Application.Common.Interfaces;
using BestFootForwardApi.Application.Common.Mappings;
using BestFootForwardApi.Application.Common.Models;
using BestFootForwardApi.Application.Shoes.Common.Dtos;

namespace BestFootForwardApi.Application.Shoes.Queries.GetShoes;

public record GetShoesQuery : IRequest<PaginatedList<ShoeDto>>
{
    public Guid? ManufacturerId { get; set; }
    public Guid? ShopId { get; set; }
    public Guid? SupplierId { get; set; }

    public SearchQuery SearchQuery { get; set; } = new();
}

public class GetShoesQueryValidator : AbstractValidator<GetShoesQuery>
{
    public GetShoesQueryValidator()
    {
    }
}

public class GetShoesQueryHandler : IRequestHandler<GetShoesQuery, PaginatedList<ShoeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetShoesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ShoeDto>> Handle(GetShoesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Shoes.Include(s => s.Manufacturer).AsNoTracking().AsQueryable();

        if (request.ManufacturerId != null)
        {
            query = query.Where(s => s.ManufacturerId.Equals(request.ManufacturerId));
        }

        if (request.ShopId != null)
        {
            var shopShoeIds = await _context.ShopShoes.AsNoTracking().Where(s => s.ShopId.Equals(request.ShopId))
                .Select(s => s.ShoeId).Distinct().ToListAsync(cancellationToken: cancellationToken);
            query = query.Where(s => shopShoeIds.Contains(s.Id));
        }

        if (request.SupplierId != null)
        {
            var supplierShoeIds = await _context.SupplierShoes.AsNoTracking()
                .Where(s => s.SupplierId.Equals(request.SupplierId))
                .Select(s => s.ShoeId).Distinct().ToListAsync(cancellationToken: cancellationToken);
            query = query.Where(s => supplierShoeIds.Contains(s.Id));
        }

        var result = await query
            .ProjectTo<ShoeDto>(_mapper.ConfigurationProvider)
            .OrderBy(d => d.Name)
            .PaginatedListAsync(request.SearchQuery.PageNumber, request.SearchQuery.PageSize);

        return result;
    }
}