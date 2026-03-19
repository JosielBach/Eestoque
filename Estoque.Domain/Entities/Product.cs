using Estoque.Domain.Validation;

namespace Estoque.Domain.Entities
{
    public sealed class Product 
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public float Stock { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; private set; }

        public void ValidateDomain(string name, string description, decimal price, DateTime registrationDate)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 2, "Invalid name, too short, minimum 2 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 characters");
            DomainExceptionValidation.When(price < 0, "Invalid price value");
            DomainExceptionValidation.When(registrationDate == default(DateTime), "Invalid registration date");
            Name = name;
            Description = description;
            this.Price = price;
            RegistrationDate = registrationDate;
        }
    }
}
