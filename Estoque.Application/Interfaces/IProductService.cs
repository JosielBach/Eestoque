using Estoque.Application.DTOs;

namespace Estoque.Application.Interfaces;

public interface IProductService 
{
    Task<IEnumerable<ProductDTO>> GetAllAsync();
    Task<IEnumerable<ProductDTO>> GetByCategory(int categoryId);
    Task<ProductDTO> GetAsync(int? id);
    Task CreateAsync(ProductDTO productDto);
    Task UpdateAsync(ProductDTO productDto);
    Task DeleteAsync(int? id);
}
