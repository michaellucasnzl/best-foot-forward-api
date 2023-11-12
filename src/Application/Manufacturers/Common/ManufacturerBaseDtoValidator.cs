using BestFootForwardApi.Application.Common.Validators;

namespace BestFootForwardApi.Application.Manufacturers.Common;

public class ManufacturerBaseDtoValidator : AbstractValidator<ManufacturerBaseDto>
{
    public ManufacturerBaseDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        When(x => x.Address != null, () => 
            { RuleFor(x => x.Address!).SetValidator(new AddressDtoValidator()); });
    }
}