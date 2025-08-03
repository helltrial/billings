namespace Billings.Application.Requests.Usages.Commands;

using Abstractions;
using Abstractions.Repositories;
using Billings.Domain.Entities;
using Domain.Events;
using Invoices.Commands;
using MediatR;

/// <summary>
/// Команда на создание записи об использовании платной функции
/// </summary>
/// <summary>
/// Команда для регистрации использования платной функции пользователем.
/// </summary>
public record CreateUsageCommand(Guid UserId, string Feature, decimal Amount) : IRequest<Guid>;

/// <summary>
/// Обработчик команды создания использования платной услуги.
/// </summary>
internal class CreateUsageCommandHandler(IEventBus eventBus, IUsageRepository usageRepository, IMediator mediator) : IRequestHandler<CreateUsageCommand, Guid>
{
    public async Task<Guid> Handle(CreateUsageCommand request, CancellationToken cancellationToken)
    {
        var usage = new Usage(
            request.UserId,
            request.Feature,
            request.Amount
        );

        await usageRepository.AddAsync(usage, cancellationToken);

        //TODO: OUTBOX PATTERN
        var evt = new UsageCreated
        {
            UsageId = Guid.NewGuid(),
            UserId = request.UserId,
            Feature = request.Feature,
            Amount = request.Amount,
            CreatedAt = DateTime.UtcNow
        };

        await eventBus.PublishAsync("usage-created", evt, cancellationToken);
        
        var command = new CreateInvoiceCommand(
            evt.UsageId,
            evt.UserId,
            evt.Feature,
            evt.Amount
        );

        await mediator.Send(command, cancellationToken);
        
        return usage.Id;
    }
}