namespace Billings.Application.Requests.Invoices.Queries;

using Abstractions.Repositories;
using Domain.Entities;
using MediatR;

/// <summary>
/// Возвращает список инвойсов по идентификатору пользователя.
/// </summary>
/// <param name="UserId"></param>
public record GetInvoicesByUserIdQuery(Guid UserId) : IRequest<IReadOnlyCollection<Invoice>>;

/// <inheritdoc />
internal class GetInvoicesByUserIdQueryHandler(IInvoiceRepository repository)
    : IRequestHandler<GetInvoicesByUserIdQuery, IReadOnlyCollection<Invoice>>
{
    public Task<IReadOnlyCollection<Invoice>> Handle(GetInvoicesByUserIdQuery request, CancellationToken cancellationToken)
    {
        return repository.GetAllByUserIdAsync(request.UserId, cancellationToken);
    }
}
