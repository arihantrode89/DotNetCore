using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class ProductAddRequest
    {
        [Required]
        [MaxLength(100,ErrorMessage ="Max Length is 100")]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(500,ErrorMessage ="Max Length is 500")]
        public string ProductDescription { get; set; }

        [Required]
        public float CurrentPrice { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Product ToProduct()
        {
            return new Product() { ProductName = ProductName, ProductDescription = ProductDescription, CurrentPrice = CurrentPrice,CategoryId=CategoryId };
        }
    }
}
