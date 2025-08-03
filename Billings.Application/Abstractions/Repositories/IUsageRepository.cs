namespace Billings.Application.Abstractions.Repositories;

using Domain.Entities;

/// <summary>
/// Репозиторий usages.
/// </summary>
public interface IUsageRepository
{
    public Task AddAsync(Usage usage, CancellationToken cancellationToken = default);
}