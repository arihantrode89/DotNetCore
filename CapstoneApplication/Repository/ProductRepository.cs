using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db=db;
        }
        public async Task<Product> AddProduct(Product ptd)
        {
            _db.Product.Add(ptd);
            await _db.SaveChangesAsync();
            return ptd;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var delObj = await _db.Product.FirstOrDefaultAsync(x => x.ProductId == productId);
            if(delObj == null) return false;
            _db.Product.Remove(delObj);
            int count = await _db.SaveChangesAsync();
            
            return count>0;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var data = await _db.Product.Include("Category").ToListAsync();
            return data;
        }

        public async Task<Product?> GetProductById(int productId)
        {
            var data = await _db.Product.Include("Category").FirstOrDefaultAsync(x => x.ProductId == productId);
            return data;
        }

        public async Task<Product> UpdateProduct(Product ptd)
        {
            if(ptd == null)
            {
                return ptd;
            }
            var oldObj = await _db.Product.Include("Category").FirstOrDefaultAsync(x=>x.ProductId == ptd.ProductId);
            oldObj.ProductName = ptd.ProductName;
            oldObj.ProductDescription = ptd.ProductDescription;
            oldObj.CurrentPrice = ptd.CurrentPrice;
            oldObj.Category = ptd.Category;

            await _db.SaveChangesAsync();
            return ptd;
        }
    }
}
