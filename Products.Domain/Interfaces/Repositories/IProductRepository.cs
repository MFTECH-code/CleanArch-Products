using Products.Domain.DTOs;
using Products.Domain.Entities;
namespace Products.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync(PaginatedFilter paginatedFilter);
        Task<Product> GetByNormalizedNameAsync(string normalizedName);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
    }
}
