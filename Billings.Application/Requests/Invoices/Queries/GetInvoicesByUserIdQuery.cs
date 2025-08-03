namespace Billings.Application.Requests.Invoices.Queries;

using Abstractions.Repositories;
using Domain.Entities;
using MediatR;

public record GetInvoicesByUserIdQuery(Guid UserId) : IRequest<IReadOnlyCollection<Invoice>>;

internal class GetInvoicesByUserIdQueryHandler(IInvoiceRepository repository)
    : IRequestHandler<GetInvoicesByUserIdQuery, IReadOnlyCollection<Invoice>>
{
    public Task<IReadOnlyCollection<Invoice>> Handle(GetInvoicesByUserIdQuery request, CancellationToken cancellationToken)
    {
        return repository.GetAllByUserIdAsync(request.UserId, cancellationToken);
    }
}
