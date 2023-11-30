using Ecommerce.Models;

namespace Ecommerce.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByName(string name);
        Task<IEnumerable<Product>> GetAllProductsByCategory(Category category);
        Task<IEnumerable<Product>> GetAllProductsWithCategory();
        Task<Product> Update(Product product);
        Task Delete(int id);

    }
}
