namespace Billings.Domain.Events;

using Abstractions;

/// <summary>
/// Событие, обозначающее генерацию нового счёта (Invoice).
/// Это событие будет передано в Kafka.
/// </summary>
public class InvoiceCreated : IDomainEvent
{
    public Guid InvoiceId { get; set; }
    public Guid UsageId { get; set; }
    public Guid UserId { get; set; }
    public string Feature { get; set; } = default!;
    public decimal Amount { get; set; }
    
    public Guid EventId { get; }
    public DateTime CreatedAt { get; set; }
}
