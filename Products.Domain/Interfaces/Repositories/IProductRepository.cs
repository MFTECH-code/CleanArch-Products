using Products.Domain.Entities;

namespace Products.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken);
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
        Task<Product> GetByNormalizedNameAsync(string normalizedName, CancellationToken cancellationToken);
    }
}
