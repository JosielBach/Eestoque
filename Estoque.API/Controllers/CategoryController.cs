using Estoque.Application.DTOs;
using Estoque.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.API.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDTO>> GetAllAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryAsync(int id)
        {
            var category = await _categoryService.GetAsync(id);
            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCategoryAsync(CategoryDTO categoryDto)
        {
            await _categoryService.CreateAsync(categoryDto);
            return Ok("Categoria criada com sucesso.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategoryAsync(int? id, CategoryDTO categoryDto)
        {
            await _categoryService.UpdateAsync(categoryDto);
            return Ok("Categoria atualizada com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoryAsync(int? id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok("Categoria deletada com sucesso.");
        }
    }
}