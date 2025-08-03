namespace Billings.Domain.Entities;

/// <summary>
/// Счёт, формируется на основе Usage.
/// </summary>
public class Invoice
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public decimal TotalAmount { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    private Invoice() { }

    // Фабричный метод создания инвойса
    public static Invoice Generate(Guid customerId, decimal totalAmount)
    {
        return new Invoice
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            TotalAmount = totalAmount,
            CreatedAt = DateTime.UtcNow
        };
    }
}