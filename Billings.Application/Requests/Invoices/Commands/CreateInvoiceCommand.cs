namespace Billings.Application.Requests.Invoices.Commands;

using Abstractions;
using Abstractions.Repositories;
using Common;
using Domain.Entities;
using Domain.Events;
using MediatR;

/// <summary>
/// Команда на создание счёта за использование.
/// </summary>
public record CreateInvoiceCommand(
    Guid UsageId,
    Guid UserId,
    string Feature,
    decimal Amount
) : IRequest<Guid>;

/// <summary>
/// Обработчик команды создания счёта.
/// </summary>
internal class CreateInvoiceCommandHandler(IEventBus eventBus, IInvoiceRepository repository)
    : IRequestHandler<CreateInvoiceCommand, Guid>
{
    public async Task<Guid> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = new Invoice(
            request.UsageId,
            request.UserId,
            request.Feature,
            request.Amount
        );

        await repository.AddAsync(invoice, cancellationToken);

        var evt = new InvoiceCreated
        {
            InvoiceId = invoice.Id,
            UsageId = invoice.UsageId,
            UserId = invoice.UserId,
            Feature = invoice.Feature,
            Amount = invoice.Amount,
            CreatedAt = invoice.CreatedAt
        };

        await eventBus.PublishAsync(KafkaTopics.InvoiceCreated, evt, cancellationToken);

        return invoice.Id;
    }
}
