namespace Billings.Infrastructure.Repositories;

using Application.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Setup;

/// <summary>
/// Репозиторий для работы с Invoice в materialized view (PostgreSQL).
/// </summary>
public class InvoiceRepository(BillingDbContext dbContext) : IInvoiceRepository
{
    public async Task AddAsync(Invoice invoice, CancellationToken cancellationToken = default)
    {
        await dbContext.Invoices.AddAsync(invoice, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<Invoice?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return dbContext.Invoices
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Invoice>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Invoices
            .AsNoTracking()
            .Where(i => i.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}
