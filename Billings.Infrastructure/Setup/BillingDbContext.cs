namespace Billings.Infrastructure.Setup;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class BillingDbContext : DbContext
{
    public BillingDbContext(
        DbContextOptions<BillingDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Usage> Usages { get; set; }
    public DbSet<Invoice> Invoices { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}