using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class ProductUpdateRequest
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

        public Product ToProduct()
        {
            return new Product { ProductId = ProductId, ProductName = ProductName, ProductDescription = ProductDescription, CurrentPrice = CurrentPrice, CategoryId = CategoryId };
        }
    }
}
