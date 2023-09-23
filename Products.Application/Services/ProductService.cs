using AutoMapper;
using Products.Application.DTOs;
using Products.Application.Interfaces.Services;
using Products.Application.Shared.Exceptions;
using Products.Domain.Entities;
using Products.Domain.Interfaces;
using Products.Domain.Interfaces.Repositories;

namespace Products.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddStcockAsync(Guid id, int quantity, CancellationToken cancellationToken)
        {
            if (quantity <= 0) throw new BadRequestException("Quantity must to be bigger than 0");
            var product = await _productRepository.GetByIdAsync(id, cancellationToken);
            if (product == null) throw new NotFoundException("Product not found");
            product.Stock += quantity;
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task CreateAsync(ProductInsertDTO productInsertDTO, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(productInsertDTO);
            _productRepository.Create(product);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(id, cancellationToken);
            if (product == null) throw new NotFoundException("Product not found");
            _productRepository.Delete(product);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task<IEnumerable<ProductGetDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            return (await _productRepository.GetAllAsync(cancellationToken))
                .Select(x => _mapper.Map<ProductGetDTO>(x));
        }

        public async Task<ProductGetDTO> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            var normalizedName = name.ToLower().Replace(" ", "_").Trim();
            var product = await _productRepository.GetByNormalizedNameAsync(normalizedName, cancellationToken);
            if (product == null) throw new NotFoundException("Product not found");
            return _mapper.Map<ProductGetDTO>(product);
        }

        public async Task<ProductGetDTO> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetByIdAsync(id, cancellationToken);
            if (product == null) throw new NotFoundException("Product not found");
            return _mapper.Map<ProductGetDTO>(product);
        }

        public async Task RemoveStockAsync(Guid id, int quantity, CancellationToken cancellationToken)
        {
            if (quantity <= 0) throw new BadRequestException("Quantity must to be bigger than 0");
            var product = await _productRepository.GetByIdAsync(id, cancellationToken);
            if (product == null) throw new NotFoundException("Product not found");
            product.Stock -= quantity;
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task UpdateAsync(ProductInsertDTO productInsertDTO, Guid id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(id, cancellationToken);
            if (product == null) throw new NotFoundException("Product not found");
            var productUpdated = _mapper.Map<Product>(productInsertDTO);
            productUpdated.CreatedDate = product.CreatedDate;
            _productRepository.Update(product);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
