namespace Billings.Extensions;

using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using Api;
using Application;
using Infrastructure;

/// <summary>
/// Конфигурация для настройки сервисов.
/// </summary>
public static class SetupExtensions
{
    /// <summary>
    /// Setups the application DI container.
    /// </summary>
    /// <param name="builder"><see cref="WebApplicationBuilder">The application builder</see>.</param>
    public static WebApplicationBuilder SetupServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddProblemDetails();

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.MaxDepth = 64;
                options.JsonSerializerOptions.IncludeFields = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddHttpContextAccessor();

        builder.Services
            .AddApi()
            .AddApplication()
            .AddInfrastructure(builder.Configuration);

        return builder;
    }
}