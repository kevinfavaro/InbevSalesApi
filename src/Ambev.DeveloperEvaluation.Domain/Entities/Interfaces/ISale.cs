namespace Ambev.DeveloperEvaluation.Domain.Entities.Interfaces;

public interface ISale
{
    Guid Id { get; }
    DateTime SaleDate { get; }
    int CustomerId { get; }
    string CustomerName { get; }
    string Branch { get; }
    bool Cancelled { get; }
    decimal TotalAmount { get; }
    ICollection<SaleItem> Items { get; }

    void Cancel();
    void AddItem(SaleItem item);
}
