using Microsoft.AspNetCore.Mvc;
using Estoque.Application.DTOs;
using Estoque.Application.Interfaces;

namespace Estoque.API.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ProductDTO>> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<ProductDTO>> GetByCategoryAsync(int categoryId)
        {
            var products = await _productService.GetByCategory(categoryId);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductAsync(int? id)
        {
            var product = await _productService.GetAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductAsync(ProductDTO productDto)
        {
            await _productService.CreateAsync(productDto);
            return Ok("Produto criado com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductAsync(int? id, ProductDTO productDto)
        {
            await _productService.UpdateAsync(productDto);
            return Ok("Produto atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync(int? id)
        {
            await _productService.DeleteAsync(id);
            return Ok("Produto deletado com sucesso.");
        }
    }
}
