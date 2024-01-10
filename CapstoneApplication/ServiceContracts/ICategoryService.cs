using Entities;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ICategoryService
    {
        Task<CategoryResponse> AddCategory(CategoryAddRequest ptd);

        Task<List<CategoryResponse>> GetCategories();

        Task<CategoryResponse?> GetCategoryById(int categoryId);

        Task<CategoryResponse> UpdateCategory(CategoryAddRequest ptd);
    }
}
