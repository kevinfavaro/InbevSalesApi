namespace Ambev.DeveloperEvaluation.Domain.Entities.Interfaces;

public interface ISaleItem
{
    int ProductId { get; }
    string ProductName { get; }
    decimal UnitPrice { get; }
    int Quantity { get; }
    decimal Discount { get; }
    decimal Total { get; }

    void ApplyDiscount();
}
