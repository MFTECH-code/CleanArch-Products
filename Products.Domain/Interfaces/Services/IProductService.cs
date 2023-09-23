using Products.Domain.DTOs;
namespace Products.Domain.Interfaces.Services
{
    public interface IProductService
    {
        #region Basic CRUD Operations
        Task<ProductGetDTO> GetProductByIdAsync(Guid id);
        Task<IEnumerable<ProductGetDTO>> GetAllPaginatedAsync(PaginatedFilter paginatedFilter);
        Task CreateAsync(ProductInsertDTO productInsertDTO);
        Task UpdateAsync(ProductInsertDTO productInsertDTO, Guid Id);
        Task DeleteAsync(Guid id);
        #endregion

        #region Business Operations
        Task AddStcockAsync(Guid id, int quantity);
        Task RemoveStockAsync(Guid id, int quantity);
        Task GetByNameAsync(string name);
        #endregion
    }
}
