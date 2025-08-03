namespace Billings.Application.Requests.Usages.Commands;

using Billings.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

/// <summary>
/// Команда на регистрацию факта потребления ресурса
/// </summary>
public record ReportUsageCommand(Guid AccountId, string Resource, decimal Amount) : IRequest;

/// <summary>
/// Обработчик команды ReportUsageCommand.
/// На текущем этапе просто логирует usage; в будущем — сохранение или публикация.
/// </summary>
public class ReportUsageCommandHandler(ILogger<ReportUsageCommandHandler> logger) : IRequestHandler<ReportUsageCommand>
{
    public Task Handle(ReportUsageCommand request, CancellationToken cancellationToken)
    {
        var usage = new Usage(request.AccountId, request.Resource, request.Amount);
        
        logger.LogInformation("Usage reported: {AccountId} {Resource} {Amount}",
            usage.AccountId, usage.Resource, usage.Amount);

        return Task.FromResult(0);
    }
}