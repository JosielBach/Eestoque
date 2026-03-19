using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces;
using Estoque.Infrastructure.Context;

namespace Estoque.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
        {
            var products = await GetAllAsync(); 
            return products.Where(p => p.CategoryId == categoryId);
        }
    }
}
