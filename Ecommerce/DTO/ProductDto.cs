using Ecommerce.Models;

namespace Ecommerce.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public long Stock { get; set; }
        public string? imageUrl { get; set; }

        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
    }
}
