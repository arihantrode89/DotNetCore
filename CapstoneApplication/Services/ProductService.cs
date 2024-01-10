using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _prodRepo;
        public ProductService(IProductRepository prodRepo)
        {
            _prodRepo = prodRepo;
        }

        public async Task<ProductResponse> AddProduct(ProductAddRequest ptd)
        {
            var data = await _prodRepo.AddProduct(ptd.ToProduct());
            var resp = await _prodRepo.GetProductById(data.ProductId);


            return resp.ToProductResponse();
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            bool succ = await _prodRepo.DeleteProduct(productId);
            return succ;
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            var data = await _prodRepo.GetAllProducts();
            data.Select(x=>x.ToProductResponse());
            return data.Select(x => x.ToProductResponse()).ToList();
        }

        public async Task<ProductResponse?> GetProductById(int productId)
        {
            var data = await _prodRepo.GetProductById(productId);
            return data.ToProductResponse();
        }

        public async Task<ProductResponse> UpdateProduct(ProductUpdateRequest ptd)
        {
            var data = await _prodRepo.GetProductById(ptd.ProductId);
            data.ProductName = ptd.ProductName;
            data.ProductDescription = ptd.ProductDescription;
            data.CurrentPrice = ptd.CurrentPrice;
            data.CategoryId = ptd.CategoryId;

            var succ = await _prodRepo.UpdateProduct(data);
            return succ.ToProductResponse();
        }
    }
}
