using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class ProductResponse
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(500)]
        public string ProductDescription { get; set; }

        [Required]
        public float CurrentPrice { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public ProductUpdateRequest ToUpdateRequest()
        {
            return new ProductUpdateRequest() { ProductId = ProductId, ProductName = ProductName, ProductDescription = ProductDescription, CurrentPrice = CurrentPrice, CategoryId = CategoryId };
        }
    }

    public static class ProductExtension
    {
        public static ProductResponse ToProductResponse(this Product ptd)
        {
            return new ProductResponse() { ProductId=ptd.ProductId,ProductName = ptd.ProductName,ProductDescription = ptd.ProductDescription,CurrentPrice=ptd.CurrentPrice,CategoryId=ptd.CategoryId, CategoryName =ptd.Category?.CategoryName};
        }
    }
}
