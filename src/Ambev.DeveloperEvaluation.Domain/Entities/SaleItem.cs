using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities.Interfaces;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale item (product and its quantity, price and discount).
/// </summary>
public class SaleItem : BaseEntity, ISaleItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Discount { get; private set; }

    public decimal Total => (UnitPrice * Quantity) - Discount;

    public void ApplyDiscount()
    {
        if (Quantity > 20)
            throw new InvalidOperationException("Cannot sell more than 20 identical items.");
        else if (Quantity >= 10)
            Discount = 0.20m * UnitPrice * Quantity;
        else if (Quantity >= 4)
            Discount = 0.10m * UnitPrice * Quantity;
        else
            Discount = 0;
    }
}
