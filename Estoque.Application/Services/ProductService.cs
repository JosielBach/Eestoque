
using AutoMapper;
using Estoque.Application.DTOs;
using Estoque.Application.Exceptions;
using Estoque.Application.Interfaces;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces;

namespace Estoque.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var productsEntity = await _unitOfWork.Products.GetAllAsync();
            if (!productsEntity.Any())
                throw new NotFoundException("Produtos nao encontraodos.");

            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }
        public async Task<IEnumerable<ProductDTO>> GetByCategory(int categoryId)
        {
            var productsEntity = await _unitOfWork.Products.GetByCategoryAsync(categoryId);
            if(productsEntity == null)
                throw new NotFoundException("Esta categoria não possui produtos ou não existe.");

            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }
        public async Task<ProductDTO> GetAsync(int? id)
        {
            var productEntity = await _unitOfWork.Products.GetAsync(p => p.ProductId == id);
            if (productEntity == null)
                throw new NotFoundException("Produto não encontrado.");

            return _mapper.Map<ProductDTO>(productEntity);
        }
        public async Task CreateAsync(ProductDTO productDto)
        {
            var product = await _unitOfWork.Products.GetAsync
                (p => p.ProductId == productDto.ProductId || p.Name == productDto.Name);
            if (product != null)
                throw new Exception("Produto já existe.");

            var productEntity = _mapper.Map<Product>(productDto);
            await _unitOfWork.Products.CreateAsync(productEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateAsync(ProductDTO productDto)
        {
            var product = await _unitOfWork.Products.GetAsync(p => p.ProductId == productDto.ProductId);
            if (product != null)
                throw new NotFoundException("Produto não encontrado.");

            var productEntity = _mapper.Map<Product>(productDto);
            await _unitOfWork.Products.UpdateAsync(productEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync(int? id)
        {
            var productEntity = await _unitOfWork.Products.GetAsync(p => p.ProductId == id);
            if (productEntity == null)
                throw new NotFoundException("Produto não encontrado.");
            
            await _unitOfWork.Products.DeleteAsync(productEntity);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
