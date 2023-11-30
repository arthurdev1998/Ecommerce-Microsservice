using Ecommerce.Context;
using Ecommerce.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
           var obj = await GetProductById(id);
           if (obj != null) 
           {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
           }

            throw new Exception($"Não foi possível deletar o Produto de Id {id}");
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategory(Category category)
        {
             return await _context.Products.Where(x => x.Category == category).Include(x => x.Category).ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<Product>> GetAllProductsWithCategory() 
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();  
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await _context.Products.Where(x => x.Name == name).Include(x => x.Category).FirstOrDefaultAsync();
        }

        public async Task<Product> Update(Product product)
        {
            Product obj = await GetProductById(product.Id);
            if (obj != null) 
            {
                obj.Price = product.Price;
                obj.Name = product.Name;
                obj.Description = product.Description;
                obj.CategoryId = product.CategoryId;
                obj.imageUrl = product.imageUrl;

                await _context.SaveChangesAsync();  
                return obj;
            }

            throw new Exception("não foi possível atualizar o produto");
        }
    }
}
