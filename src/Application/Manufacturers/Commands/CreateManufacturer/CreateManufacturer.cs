using BestFootForwardApi.Application.Common.Interfaces;

namespace BestFootForwardApi.Application.Manufacturers.Commands.CreateManufacturer;

public record CreateManufacturerCommand : IRequest<Guid>
{
}

public class CreateManufacturerCommandValidator : AbstractValidator<CreateManufacturerCommand>
{
    public CreateManufacturerCommandValidator()
    {
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
        throw new NotImplementedException();
    }
}
