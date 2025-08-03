namespace Billings.Application.Abstractions.Repositories;

using Domain.Entities;

/// <summary>
/// Репозиторий инвойсов.
/// </summary>
public interface IInvoiceRepository
{
    /// <summary>
    /// Создает запись.
    /// </summary>
    /// <param name="invoice">invoice.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddAsync(Invoice invoice, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает запись по id.
    /// </summary>
    /// <param name="id">id.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Invoice?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Возвращает инвойсы по идентификатору юзера.
    /// </summary>
    /// <param name="userId">userId.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IReadOnlyCollection<Invoice>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}