namespace Billings.Domain.Entities;

/// <summary>
/// Представляет факт использования платной функции пользователем.
/// Используется для расчёта задолженности.
/// </summary>
public class Usage
{
    /// <summary>
    /// Уникальный идентификатор использования.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Идентификатор пользователя, совершившего действие.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Название функции, которая была использована (например, "boost_listing").
    /// </summary>
    public string Feature { get; set; } = default!;

    /// <summary>
    /// Стоимость использования функции.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Временная метка, когда произошло использование.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    private Usage()
    {
    }

    public Usage(Guid userId, string feature, decimal amount)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Feature = feature;
        Amount = amount;
        CreatedAt = DateTime.UtcNow;
    }
}