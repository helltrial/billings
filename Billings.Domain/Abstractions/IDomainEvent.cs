namespace Billings.Domain.Abstractions;

/// <summary>
/// Базовый интерфейс для всех доменных событий.
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// Уникальный идентификатор события (используется для идемпотентности и трассировки).
    /// </summary>
    Guid EventId { get; }

    /// <summary>
    /// Время, когда произошло событие (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; }
}