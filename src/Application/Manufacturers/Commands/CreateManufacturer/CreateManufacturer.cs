using BestFootForwardApi.Application.Common.Interfaces;
using BestFootForwardApi.Application.Manufacturers.Common;
using BestFootForwardApi.Domain.Entities;

namespace BestFootForwardApi.Application.Manufacturers.Commands.CreateManufacturer;

public record CreateManufacturerCommand : IRequest<Guid>
{
    public required CreateManufacturerDto Manufacturer { get; set; }
}

public class CreateManufacturerCommandValidator : AbstractValidator<CreateManufacturerCommand>
{
    public CreateManufacturerCommandValidator()
    {
        RuleFor(m => m.Manufacturer).NotNull();
        RuleFor(m => m.Manufacturer).SetValidator(new ManufacturerBaseDtoValidator());
    }
}

public class CreateManufacturerCommandHandler : IRequestHandler<CreateManufacturerCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateManufacturerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Manufacturer()
        {
            Name = request.Manufacturer.Name,
        };

        if (request.Manufacturer.Address != null)
        {
            entity.Address = new Address
            {
                Address1 = request.Manufacturer.Address.Address1,
                Address2 = request.Manufacturer.Address.Address2,
                Suburb = request.Manufacturer.Address.Suburb,
                City = request.Manufacturer.Address.City,
                PostCode = request.Manufacturer.Address.PostCode,
                Country = request.Manufacturer.Address.Country,
            };
        }

        _context.Manufacturers.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}