namespace Billings.Domain.Events;

using Abstractions;

public class UsageCreated : IDomainEvent
{
    public Guid UsageId { get; set; }
    public Guid UserId { get; set; }
    public string Feature { get; set; }
    public decimal Amount { get; set; }
    
    public Guid EventId { get; }
    public DateTime CreatedAt { get; set; }
}