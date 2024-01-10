using Entities;
using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IProductService
    {
        Task<ProductResponse> AddProduct(ProductAddRequest ptd);

        Task<List<ProductResponse>> GetAllProducts();

        Task<ProductResponse?> GetProductById(int productId);

        Task<ProductResponse> UpdateProduct(ProductUpdateRequest ptd);

        Task<bool> DeleteProduct(int productId);
    }
}
