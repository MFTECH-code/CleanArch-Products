using Products.Domain.Interfaces;
using Products.Persistence.Context;

namespace Products.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
