using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category ptd);

        Task<List<Category>> GetCategories();

        Task<Category?> GetCategoryById(int categoryId);

        Task<Category> UpdateCategory(Category ptd);
    }
}
