namespace Billings.Domain.Entities;

/// <summary>
/// Представляет собой выставленный пользователю счёт за использование платной функции.
/// </summary>
public class Invoice
{
    /// <summary>
    /// Уникальный идентификатор счёта.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Идентификатор использования, за которое выставлен счёт.
    /// </summary>
    public Guid UsageId { get; set; }

    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Название платной функции.
    /// </summary>
    public string Feature { get; set; } = default!;

    /// <summary>
    /// Сумма к оплате.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Дата выставления счёта.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    private Invoice() { }

    public Invoice(Guid usageId, Guid userId, string feature, decimal amount)
    {
        Id = Guid.NewGuid();
        UsageId = usageId;
        UserId = userId;
        Feature = feature;
        Amount = amount;
        CreatedAt = DateTime.UtcNow;
    }
}