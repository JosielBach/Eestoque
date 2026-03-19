using Estoque.Domain.Interfaces;
using Estoque.Infrastructure.Context;

namespace Estoque.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IProductRepository _productRep;
        public ICategoryRepository _categoryRep;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IProductRepository Products
        {
            get
            {
                return _productRep = _productRep ?? new ProductRepository(_context);
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                return _categoryRep = _categoryRep ?? new CategoryRepository(_context);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
