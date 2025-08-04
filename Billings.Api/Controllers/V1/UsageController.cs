namespace Billings.Api.Controllers.V1;

using Application.Requests.Invoices.Queries;
using Billings.Application.Requests.Usages.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Контроллер для регистрации потребления ресурсов
/// </summary>
[Route("api/v1/[controller]")]
public class UsageController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Регистрирует факт потребления ресурса
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> ReportUsage([FromBody] CreateUsageCommand command)
    {
        await mediator.Send(command);
        return Ok("Usage accepted");
    }

    /// <summary>
    /// Получение записи по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var invoice = await mediator.Send(new GetInvoiceByIdQuery(id));
        return invoice is null ? NotFound() : Ok(invoice);
    }

    /// <summary>
    /// Получение всех записей по идентификатору пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор юзера.</param>
    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        var invoices = await mediator.Send(new GetInvoicesByUserIdQuery(userId));
        return Ok(invoices);
    }
}