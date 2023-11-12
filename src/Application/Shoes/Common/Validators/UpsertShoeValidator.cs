using BestFootForwardApi.Application.Shoes.Common.Dtos;

namespace BestFootForwardApi.Application.Shoes.Common.Validators;

public class UpsertShoeValidator: AbstractValidator<ShoeDto>
{
    public UpsertShoeValidator()
    {
        RuleFor(s => s.Name).NotEmpty().MaximumLength(50);
        RuleFor(s => s.ColourCode).NotEmpty();
        RuleFor(s => s.Size).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(s => s.Description).MaximumLength(500);
        RuleFor(s => s.ImageUrl).MaximumLength(200);    
    }
}
