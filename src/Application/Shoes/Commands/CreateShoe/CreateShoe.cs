using BestFootForwardApi.Application.Common.Interfaces;
using BestFootForwardApi.Application.Shoes.Common;
using BestFootForwardApi.Application.Shoes.Common.Validators;
using BestFootForwardApi.Domain.Entities;

namespace BestFootForwardApi.Application.Shoes.Commands.CreateShoe;

public record CreateShoeCommand : IRequest<Guid>
{
    public required Shoe Shoe { get; set; }
}

public class CreateShoeCommandValidator : AbstractValidator<CreateShoeCommand>
{
    public CreateShoeCommandValidator()
    {
        RuleFor(_ => _.Shoe).SetValidator(new UpsertShoeValidator());
        RuleFor(_ => _.Shoe.ManufacturerId).NotNull();
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
            CreatedBy = "todo: Get username or Id from bearer token",
            ManufacturerId = request.Shoe.ManufacturerId,
            Description = request.Shoe.Description
        };

        _context.Shoes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
