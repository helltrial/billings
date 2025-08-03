namespace Billings.Infrastructure.Repositories;

using Application.Abstractions.Repositories;
using Domain.Entities;
using Setup;

/// <summary>
/// Репозиторий для работы с Usage в materialized view (PostgreSQL).
/// </summary>
public class UsageRepository(BillingDbContext dbContext) : IUsageRepository
{
    public async Task AddAsync(Usage usage, CancellationToken cancellationToken = default)
    {
        await dbContext.Usages.AddAsync(usage, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
