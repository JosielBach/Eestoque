namespace Estoque.Application.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Stock { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string ImageUrl { get; set; }

    }
}
