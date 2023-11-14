using BestFootForwardApi.Application.Common.Interfaces;
using BestFootForwardApi.Application.Manufacturers.Common;
using BestFootForwardApi.Domain.Entities;

namespace BestFootForwardApi.Application.Manufacturers.Queries.GetManufacturer;

public record GetManufacturerQuery : IRequest<ManufacturerBaseDto>
{
    public Guid Id { get; set; }
}

public class GetManufacturerQueryValidator : AbstractValidator<GetManufacturerQuery>
{
    public GetManufacturerQueryValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEqual(Guid.Empty);
    }
}

public class GetManufacturerQueryHandler : IRequestHandler<GetManufacturerQuery, ManufacturerBaseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetManufacturerQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ManufacturerBaseDto> Handle(GetManufacturerQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Manufacturers.AsNoTracking()
            .Include(x => x.Shoes)
            .Where(x => x.Id.Equals(request.Id))
            .ProjectTo<GetManufacturerDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(request.Id.ToString(), typeof(Manufacturer).FullName!);
        }

        return entity;
    }
}