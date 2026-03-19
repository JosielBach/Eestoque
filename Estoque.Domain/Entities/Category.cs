using Estoque.Domain.Validation;

namespace Estoque.Domain.Entities
{
    public sealed class Category  
    {
        public int CategoryId { get; private set; }
        public string Name { get; private set; }
        public string ImageUrl { get; private set; }
        public ICollection<Product> Products { get; set; }
      
        public void ValidateDomain(string name, string imageUrl)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 2, "Invalid name, too short, minimum 2 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(imageUrl), "Invalid imageUrl. ImageUrl is required");
            DomainExceptionValidation.When(imageUrl.Length < 5, "Invalid imageUrl, too short, minimum 5 characters");
        }

    }
}
