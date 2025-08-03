namespace Billings.Api;

using Microsoft.Extensions.DependencyInjection;

public static class ApiModule
{
    /// <summary>
    /// Регистрирует слой Api.
    /// </summary>
    /// <param name="services">IServiceCollection.</param>
    /// <returns></returns>
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        return services;
    }
}