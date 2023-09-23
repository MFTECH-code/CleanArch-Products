using Products.Application.DTOs;

namespace Products.Application.Interfaces.Services
{
    public interface IProductService
    {
        #region Basic CRUD Operations
        Task<ProductGetDTO> GetProductByIdAsync(Guid id , CancellationToken cancellationToken);
        Task<IEnumerable<ProductGetDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task CreateAsync(ProductInsertDTO productInsertDTO, CancellationToken cancellationToken);
        Task UpdateAsync(ProductInsertDTO productInsertDTO, Guid Id, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        #endregion

        #region Business Operations
        Task AddStcockAsync(Guid id, int quantity, CancellationToken cancellationToken);
        Task RemoveStockAsync(Guid id, int quantity, CancellationToken cancellationToken);
        Task<ProductGetDTO> GetByNameAsync(string name, CancellationToken cancellationToken);
        #endregion
    }
}
