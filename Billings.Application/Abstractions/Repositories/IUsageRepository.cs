namespace Billings.Application.Abstractions.Repositories;

using Domain.Entities;

/// <summary>
/// Репозиторий usages.
/// </summary>
public interface IUsageRepository
{
    /// <summary>
    /// Создает запись.
    /// </summary>
    /// <param name="usage">Usage.</param>
    /// <param name="cancellationToken">Токен.</param>
    /// <returns></returns>
    public Task AddAsync(Usage usage, CancellationToken cancellationToken = default);
}