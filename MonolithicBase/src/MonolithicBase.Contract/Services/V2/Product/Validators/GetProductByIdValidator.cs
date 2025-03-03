using FluentValidation;

namespace MonolithicBase.Contract.Services.V2.Product.Validators;

public class GetProductByIdValidator : AbstractValidator<Query.GetProductByIdQuery>
{
    public GetProductByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
