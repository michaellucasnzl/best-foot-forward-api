using BestFootForwardApi.Application.Common.Interfaces;

namespace BestFootForwardApi.Application.Manufacturers.Commands.UpdateManufacturer;

public record UpdateManufacturerCommand : IRequest<Guid>
{
}

public class UpdateManufacturerCommandValidator : AbstractValidator<UpdateManufacturerCommand>
{
    public UpdateManufacturerCommandValidator()
    {
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
        throw new NotImplementedException();
    }
}
