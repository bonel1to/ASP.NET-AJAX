using ASP4.Domain;

namespace ASP4.Application.Common.Abstractions;

public interface IProductRepository
{
    Task<Product?> GetAsync(Guid id, CancellationToken ct);
    void Add(Product product);
}
