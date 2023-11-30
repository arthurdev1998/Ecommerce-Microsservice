using Ecommerce.Context;
using Ecommerce.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) 
        {
            _context = context;
        } 
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task <IEnumerable<Category>> GetCategoriesWithProduct(Product product)
        {
            return await _context.Categories.Include(x => x.Products).ToListAsync();
        }

        public async Task<Category> GetProductByName(string name)
        {
            return await _context.Categories.Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<Category> Update(Category category)
        {
            Category obj = await GetCategoryById(category.Id);
            if (obj != null) 
            {
                obj.Id = category.Id;
                obj.Name = category.Name;

                _context.SaveChanges();
                return obj;
            }
            throw new Exception ("Não foi possivel atualizar a categoria")
        }
    }
}
