namespace Billings.Application.Requests.Invoices.Queries;

using Abstractions.Repositories;
using Domain.Entities;
using MediatR;

public record GetInvoiceByIdQuery(Guid Id) : IRequest<Invoice?>;

internal class GetInvoiceByIdQueryHandler(IInvoiceRepository repository)
    : IRequestHandler<GetInvoiceByIdQuery, Invoice?>
{
    public Task<Invoice?> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        return repository.GetByIdAsync(request.Id, cancellationToken);
    }
}
