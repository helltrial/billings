namespace Billings.Api.Controllers.V1;

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
}