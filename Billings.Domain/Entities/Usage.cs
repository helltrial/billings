namespace Billings.Domain.Entities;

/// <summary>
/// Представляет факт потребления ресурса конкретным аккаунтом.
/// Используется как основа для расчёта инвойсов.
/// </summary>
public class Usage
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    /// <summary>
    /// Идентификатор аккаунта, совершившего потребление
    /// </summary>
    public Guid AccountId { get; private set; }

    /// <summary>
    /// Тип ресурса (например, "storage", "sms")
    /// </summary>
    public string Resource { get; private set; } = string.Empty;

    /// <summary>
    /// Количество потребленного ресурса
    /// </summary>
    public decimal Amount { get; private set; }

    /// <summary>
    /// Время потребления ресурса
    /// </summary>
    public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
    
    private Usage() { }

    /// <summary>
    /// Создаёт новую запись о потреблении ресурса
    /// </summary>
    public Usage(Guid accountId, string resource, decimal amount, DateTime? timestamp = null)
    {
        AccountId = accountId;
        Resource = resource;
        Amount = amount;
        Timestamp = timestamp ?? DateTime.UtcNow;
    }
}