using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repositories;
using Products.Persistence.Context;

namespace Products.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Product product)
        {
            product.CreatedDate = DateTime.UtcNow;
            _appDbContext.Add(product);
        }

        public void Delete(Product product)
        {
            _appDbContext.Remove(product);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.Products.ToListAsync(cancellationToken);
        }

        public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Product> GetByNormalizedNameAsync(string normalizedName, CancellationToken cancellationToken)
        {
            return await _appDbContext.Products.FirstOrDefaultAsync(x => x.NormalizedName == normalizedName, cancellationToken);
        }

        public void Update(Product product)
        {
            product.UpdatedDate = DateTime.UtcNow;
            _appDbContext.Update(product);
        }
    }
}
