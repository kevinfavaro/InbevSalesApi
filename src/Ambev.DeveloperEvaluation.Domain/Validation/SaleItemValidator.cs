using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(i => i.ProductId).GreaterThan(0);
        RuleFor(i => i.ProductName).NotEmpty().MaximumLength(150);
        RuleFor(i => i.UnitPrice).GreaterThan(0);
        RuleFor(i => i.Quantity).InclusiveBetween(1, 20);
    }
}
