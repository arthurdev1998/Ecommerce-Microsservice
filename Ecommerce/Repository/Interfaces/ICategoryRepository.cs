using Ecommerce.Models;

namespace Ecommerce.Repository.Interfaces
{
    public interface ICategoryRepository
    {

        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetCategoryById(int id);
        Task<Category> GetProductByName(string name);
        Task<Category> GetCategoryWithProduct(Category category);
        Task<Category> Update(Category category);
        Task Delete(int id);

    }
}
