namespace Billings.Api.Controllers.V1;

using Billings.Application.Requests.Invoices.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Контроллер для работы со счётами.
/// </summary>
[Route("api/v1/[controller]")]
public class InvoicesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Генерирует новый счёт для указанного аккаунта и периода.
    /// </summary>
    [HttpPost("generate")]
    public async Task<IActionResult> GenerateInvoice([FromBody] CreateInvoiceCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }
}