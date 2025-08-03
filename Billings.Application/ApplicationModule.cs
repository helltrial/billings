namespace Billings.Application;

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationModule
{
    /// <summary>
    /// Регистрирует слоя Application.
    /// </summary>
    /// <param name="services">IServiceCollection.</param>
    /// <returns></returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(
            cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

        return services;
    }
}