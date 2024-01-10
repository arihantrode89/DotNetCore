using Entities;

namespace RepositoryContracts
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product ptd);

        Task<List<Product>> GetAllProducts();

        Task<Product?> GetProductById(int productId);

        Task<Product> UpdateProduct(Product ptd);

        Task<bool> DeleteProduct(int productId);
    }
}
