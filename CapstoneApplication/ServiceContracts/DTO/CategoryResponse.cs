using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class CategoryResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription {  get; set; }

    }

    public static class CategoryExtension
    {
        public static CategoryResponse ToCategoryResponse(this Category category)
        {
            return new CategoryResponse() { CategoryId = category.CategoryId, CategoryName = category.CategoryName, CategoryDescription = category.CategoryDescription };
        }
    }
}
