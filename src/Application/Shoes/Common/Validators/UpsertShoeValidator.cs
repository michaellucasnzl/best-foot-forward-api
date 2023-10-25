using BestFootForwardApi.Domain.Entities;

namespace BestFootForwardApi.Application.Shoes.Common.Validators;

public class UpsertShoeValidator: AbstractValidator<Shoe>
{
    public UpsertShoeValidator()
    {
        RuleFor(_ => _).NotNull();
        RuleFor(_ => _.Name).NotEmpty();
        RuleFor(_ => _.Colour).NotNull().NotEmpty();
        RuleFor(_ => _.Size).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(_ => _.Description).MaximumLength(500);
        RuleFor(_ => _.ImageUrl).MaximumLength(200);    
    }
}
