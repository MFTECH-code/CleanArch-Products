using Microsoft.AspNetCore.Mvc;
using Products.Application.DTOs;
using Products.Application.Interfaces.Services;
using Products.Application.Shared.Exceptions;

namespace Products.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductGetDTO>> Get(CancellationToken cancellationToken)
        {
            return await _productService.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _productService.GetProductByIdAsync(id, cancellationToken));
            }
            catch (NotFoundException)
            {
                Console.WriteLine($"Produto não encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro na solicitação: {ex.Message}");
                throw;
            }
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> Get(string name, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _productService.GetByNameAsync(name, cancellationToken));
            }
            catch (NotFoundException)
            {
                Console.WriteLine($"Produto não encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro na solicitação: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductInsertDTO productInsertDTO, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productService.CreateAsync(productInsertDTO, cancellationToken);
                return Created($"{HttpContext.Request.Path}/{product.Id}" ,product);
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro na solicitação: {ex.Message}");
                throw;
            }
        }

        [HttpPost("AddStock")]
        public async Task<IActionResult> AddStock([FromBody] ChangeStockDto changeStockDto, CancellationToken cancellationToken)
        {
            try
            {
                await _productService.AddStcockAsync(changeStockDto.Id, changeStockDto.Quantity, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro na solicitação: {ex.Message}");
                throw;
            }
        }

        [HttpPost("RemoveStock")]
        public async Task<IActionResult> RemoveStock([FromBody] ChangeStockDto changeStockDto, CancellationToken cancellationToken)
        {
            try
            {
                await _productService.RemoveStockAsync(changeStockDto.Id, changeStockDto.Quantity, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro na solicitação: {ex.Message}");
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ProductInsertDTO productInsertDTO, Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _productService.UpdateAsync(productInsertDTO, id, cancellationToken);
                return NoContent();
            }
            catch (NotFoundException)
            {
                Console.WriteLine($"Produto não encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro na solicitação: {ex.Message}");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _productService.DeleteAsync(id, cancellationToken);
                return NoContent();
            }
            catch (NotFoundException)
            {
                Console.WriteLine($"Produto não encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro na solicitação: {ex.Message}");
                throw;
            }
        }

    }
}
