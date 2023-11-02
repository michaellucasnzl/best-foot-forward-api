using BestFootForwardApi.Application.Common.Interfaces;
using BestFootForwardApi.Application.Shoes.Common.Validators;
using BestFootForwardApi.Domain.Entities;

namespace BestFootForwardApi.Application.Shoes.Commands.CreateShoe;

public record CreateShoeCommand : IRequest<Guid>
{
    public required Shoe Shoe { get; set; } //todo: do we want domain objects passed in here? Ideally not. Create a different object here and do a mapping to a domain object.
}

public class CreateShoeCommandValidator : AbstractValidator<CreateShoeCommand>
{
    public CreateShoeCommandValidator()
    {
        RuleFor(c => c.Shoe).SetValidator(new UpsertShoeValidator());
        RuleFor(c => c.Shoe.ManufacturerId).NotNull();
    }
}

public class CreateShoeCommandHandler : IRequestHandler<CreateShoeCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateShoeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateShoeCommand request, CancellationToken cancellationToken)
    {
        var entity = new Shoe()
        {
            Name = request.Shoe!.Name,
            Size = request.Shoe!.Size,
            Colour = request.Shoe!.Colour,
            ManufacturerId = request.Shoe.ManufacturerId,
            Description = request.Shoe.Description,
            ImageUrl = request.Shoe.ImageUrl
        };

        _context.Shoes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
