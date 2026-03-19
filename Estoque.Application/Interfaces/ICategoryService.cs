
using Estoque.Application.DTOs;

namespace Estoque.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO> GetAsync(int id);
        Task CreateAsync(CategoryDTO categoryDto);
        Task UpdateAsync(CategoryDTO categoryDto);
        Task DeleteAsync(int? id);
    }
}
