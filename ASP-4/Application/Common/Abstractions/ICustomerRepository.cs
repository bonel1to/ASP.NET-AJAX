using ASP4.Domain;

namespace ASP4.Application.Common.Abstractions;

public interface ICustomerRepository
{
    Task<Customer?> GetByEmailAsync(string email, CancellationToken ct);
    void Add(Customer customer);
}
