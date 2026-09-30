using ASP4.Domain;

namespace ASP4.Application.Common.Abstractions;

public interface IOrderRepository
{
    Task<Order?> GetAsync(Guid id, CancellationToken ct);
    void Add(Order order);
}
