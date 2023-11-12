using BestFootForwardApi.Application.Common.Interfaces;
using BestFootForwardApi.Application.Manufacturers.Common;
using BestFootForwardApi.Domain.Entities;

namespace BestFootForwardApi.Application.Manufacturers.Commands.UpdateManufacturer;

public record UpdateManufacturerCommand : IRequest<Guid>
{
    public required UpdateManufacturerDto Manufacturer { get; set; }
}

public class UpdateManufacturerCommandValidator : AbstractValidator<UpdateManufacturerCommand>
{
    public UpdateManufacturerCommandValidator()
    {
        RuleFor(m => m.Manufacturer).NotNull();
        RuleFor(m => m.Manufacturer.Id).NotNull();
        RuleFor(_ => _.Manufacturer).SetValidator(new ManufacturerBaseDtoValidator());
    }
}

public class UpdateManufacturerCommandHandler : IRequestHandler<UpdateManufacturerCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdateManufacturerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Manufacturers
            .Include(x => x.Address)
            .Where(x => x.Id.Equals(request.Manufacturer.Id))
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Manufacturer.Id!.Value, entity);

        entity.Name = request.Manufacturer.Name;

        if (request.Manufacturer.Address != null)
        {
            entity.Address ??= new Address
            {
                Address1 = null!,
                PostCode = null!,
                City = null!
            };

            entity.Address.Address1 = request.Manufacturer.Address.Address1;
            entity.Address.Address2 = request.Manufacturer.Address.Address2;
            entity.Address.Suburb = request.Manufacturer.Address.Suburb;
            entity.Address.City = request.Manufacturer.Address.City;
            entity.Address.PostCode = request.Manufacturer.Address.PostCode;
            entity.Address.Country = request.Manufacturer.Address.Country;
        }

        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}