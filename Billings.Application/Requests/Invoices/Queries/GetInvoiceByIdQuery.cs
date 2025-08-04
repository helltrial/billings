namespace Billings.Application.Requests.Invoices.Queries;

using Abstractions.Repositories;
using Domain.Entities;
using MediatR;

/// <summary>
/// Возвращает инвойс по идентификатору.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetInvoiceByIdQuery(Guid Id) : IRequest<Invoice?>;

/// <inheritdoc />
internal class GetInvoiceByIdQueryHandler(IInvoiceRepository repository)
    : IRequestHandler<GetInvoiceByIdQuery, Invoice?>
{
    public Task<Invoice?> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        return repository.GetByIdAsync(request.Id, cancellationToken);
    }
}
