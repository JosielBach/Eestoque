namespace Estoque.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products  { get; }
        ICategoryRepository Categories { get; }
        Task SaveChangesAsync();
    }
}
