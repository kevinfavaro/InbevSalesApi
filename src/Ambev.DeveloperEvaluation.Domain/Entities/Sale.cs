using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale in the system.
/// </summary>
public class Sale : BaseEntity, ISale
{
    public DateTime SaleDate { get; private set; }
    public int CustomerId { get; private set; }
    public string CustomerName { get; private set; } = string.Empty;
    public string Branch { get; private set; } = string.Empty;
    public bool Cancelled { get; private set; }
    public ICollection<SaleItem> Items { get; private set; } = new List<SaleItem>();

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public decimal TotalAmount => Items.Sum(i => i.Total);

    public Sale()
    {
        CreatedAt = DateTime.UtcNow;
        SaleDate = DateTime.UtcNow;
    }

    public void Cancel()
    {
        Cancelled = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddItem(SaleItem item)
    {
        item.ApplyDiscount();
        Items.Add(item);
        UpdatedAt = DateTime.UtcNow;
    }

    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
        };
    }
}
