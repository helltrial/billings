namespace Billings.Application.Abstractions;

using Domain.Abstractions;

public interface IEventBus
{
    Task PublishAsync<T>(string topic, T @event) where T: IDomainEvent;
}