namespace Billings.Api.Controllers;

using Application.Requests.Usages.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Контроллер для регистрации потребления ресурсов
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsageController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Регистрирует факт потребления ресурса
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> ReportUsage([FromBody] ReportUsageCommand command)
    {
        await mediator.Send(command);
        return Ok("Usage accepted");
    }
}