namespace Billings.Application.Requests.Invoices.Commands;

using Abstractions;
using Domain.Entities;
using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

/// <summary>
/// Команда на генерацию нового счёта (Invoice) для указанного клиента.
/// </summary>
public class GenerateInvoiceCommand : IRequest
{
    /// <summary>
    /// Идентификатор клиента, для которого генерируется счёт.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Итоговая сумма счёта.
    /// </summary>
    public decimal TotalAmount { get; set; }
}

/// <inheritdoc />
internal class GenerateInvoiceCommandHandler(IEventBus eventBus, ILogger<GenerateInvoiceCommandHandler> logger) : IRequestHandler<GenerateInvoiceCommand>
{
    /// <inheritdoc />
    public async Task Handle(GenerateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = Invoice.Generate(request.CustomerId, request.TotalAmount);

        var evt = new InvoiceGenerated
        {
            InvoiceId = invoice.Id,
            CustomerId = invoice.CustomerId,
            TotalAmount = invoice.TotalAmount,
            CreatedAt = invoice.CreatedAt
        };

        await eventBus.PublishAsync("invoice-generated", evt);

        logger.LogInformation("Инвойс {InvoiceId} сгенерирован и отправлен в Kafka.", invoice.Id);
    }
}
