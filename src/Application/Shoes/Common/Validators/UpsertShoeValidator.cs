using BestFootForwardApi.Domain.Entities;

namespace BestFootForwardApi.Application.Shoes.Common.Validators;

public class UpsertShoeValidator: AbstractValidator<Shoe>
{
    public UpsertShoeValidator()
    {
        RuleFor(s => s).NotNull();
        RuleFor(s => s.Name).NotEmpty().MaximumLength(50);
        RuleFor(s => s.Colour).NotNull().NotEmpty();
        RuleFor(s => s.Size).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(s => s.Description).MaximumLength(500);
        RuleFor(s => s.ImageUrl).MaximumLength(200);    
    }
}
