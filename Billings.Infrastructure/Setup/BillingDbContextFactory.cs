namespace Billings.Infrastructure.Setup;

using Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class BillingDbContextFactory : IDesignTimeDbContextFactory<BillingDbContext>
{
    /// <inheritdoc/>
    public BillingDbContext CreateDbContext(string[] args)
    {
        var keyValuePairs = new KeyValuePair<string, string>[]
        {
            new("Database:DbType", "postgres"),
            new("Database:EnableSensitiveDataLogging", "true"),
            new(
                "ConnectionStrings:generation",
                "Server=localhost;Database=generation;User Id=postgres;Password=password"),
        };

        IConfiguration cfg = new ConfigurationBuilder()
            .AddInMemoryCollection(keyValuePairs!)
            .Build();

        var serviceProvider = new ServiceCollection()
            .AddScoped<IMediator, Mediator>()
            .AddDbContextLayer(cfg)
            .BuildServiceProvider();

        var ctx = serviceProvider.GetRequiredService<BillingDbContext>();

        return ctx;
    }
}