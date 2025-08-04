namespace Billings.Application.Abstractions;

using Domain.Abstractions;

/// <summary>
/// Интерфейс взаимодействия с брокером.
/// </summary>
public interface IEventBus
{
    /// <summary>
    /// Публикация события в топик.
    /// </summary>
    /// <param name="topic">Название топика.</param>
    /// <param name="event">Событиие.</param>
    /// <param name="cancellation">Токен отмены.</param>
    /// <typeparam name="T">Тип события.</typeparam>
    Task PublishAsync<T>(string topic, T @event, CancellationToken cancellation = default) where T: IDomainEvent;
}