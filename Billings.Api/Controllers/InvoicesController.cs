namespace Billings.Api.Controllers;

using Application.Requests.Invoices.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Контроллер для работы со счётами.
/// </summary>
[ApiController]
[Route("api/invoices")]
public class InvoicesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Генерирует новый счёт для указанного аккаунта и периода.
    /// </summary>
    [HttpPost("generate")]
    public async Task<IActionResult> GenerateInvoice([FromBody] GenerateInvoiceCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }
}