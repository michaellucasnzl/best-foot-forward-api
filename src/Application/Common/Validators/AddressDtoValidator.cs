using BestFootForwardApi.Application.Common.Models;

namespace BestFootForwardApi.Application.Common.Validators;

public class AddressDtoValidator : AbstractValidator<AddressDto>
{
    public AddressDtoValidator()
    {
        RuleFor(_ => _.Address1).NotEmpty().MaximumLength(100);
        RuleFor(_ => _.Address2).MaximumLength(100);
        RuleFor(_ => _.Suburb).MaximumLength(50);
        RuleFor(_ => _.City).NotEmpty().MaximumLength(50);
        RuleFor(_ => _.PostCode).NotEmpty().MaximumLength(10);
        RuleFor(_ => _.Country).NotEmpty().MaximumLength(50);
    }
}