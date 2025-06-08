using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(s => s.CustomerId).GreaterThan(0);
        RuleFor(s => s.CustomerName).NotEmpty().MaximumLength(150);
        RuleFor(s => s.Branch).NotEmpty().MaximumLength(100);
        RuleFor(s => s.SaleDate).NotEmpty();
        RuleFor(s => s.Items)
            .NotEmpty().WithMessage("A venda deve conter pelo menos um item.")
            .Must(i => i.All(item => item.Quantity <= 20))
            .WithMessage("Nenhum item pode ter mais que 20 unidades.");

        RuleForEach(s => s.Items).SetValidator(new SaleItemValidator());
    }
}
