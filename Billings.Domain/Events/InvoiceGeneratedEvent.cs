namespace Billings.Domain.Events;

using Abstractions;

/// <summary>
/// Событие, обозначающее генерацию нового счёта (Invoice).
/// Это событие будет передано в Kafka.
/// </summary>
public class InvoiceGenerated : IDomainEvent
{
    public Guid EventId { get; init; } = Guid.NewGuid();
    public Guid InvoiceId { get; set; }
    public Guid CustomerId { get; set; }
    
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
}