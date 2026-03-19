using AutoMapper;
using Estoque.Application.DTOs;
using Estoque.Application.Interfaces;
using Estoque.Domain.Interfaces;
using Estoque.Domain.Entities;
using Estoque.Application.Exceptions;

namespace Estoque.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var categoryEntity = await _unitOfWork.Categories.GetAllAsync();
            if (!categoryEntity.Any())
                throw new NotFoundException("Categorias não encontrada ou não existe.");

            return _mapper.Map<IEnumerable<CategoryDTO>>(categoryEntity);
        }
        public async Task<CategoryDTO> GetAsync(int id)
        {
            var categoryEntity = await _unitOfWork.Categories.GetAsync(c => c.CategoryId == id);
            if (categoryEntity == null)
                throw new NotFoundException("Categoria não encontrada ou não existe.");

            return _mapper.Map<CategoryDTO>(categoryEntity);
        }
        public async Task CreateAsync(CategoryDTO categoryDto)
        {
            var category = await _unitOfWork.Categories.GetAsync
                (c => c.CategoryId == categoryDto.CategoryId || c.Name == categoryDto.Name);
            if (category != null)
                throw new ValidationException("Categoria já existe.");

            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.Categories.CreateAsync(categoryEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateAsync(CategoryDTO categoryDto)
        {
            var categoryEntity = await _unitOfWork.Categories.GetAsync(c => c.CategoryId == categoryDto.CategoryId);
            if (categoryEntity == null)
                throw new NotFoundException("Categoria não encontrada");

            _mapper.Map(categoryDto, categoryEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync(int? id)
        {
            var categoryEntity = await _unitOfWork.Categories.GetAsync(c => c.CategoryId == id);
            if (categoryEntity == null)
                throw new NotFoundException("Categoria não encontrada.");

            await _unitOfWork.Categories.DeleteAsync(categoryEntity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
