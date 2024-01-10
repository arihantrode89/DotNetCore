using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _ctgRepo;
        public CategoryService(ICategoryRepository category)
        {
            _ctgRepo = category;
        }

        public async Task<CategoryResponse> AddCategory(CategoryAddRequest ptd)
        {
            var data = await _ctgRepo.AddCategory(ptd.ToCategory());
            return data.ToCategoryResponse();
        }

        public async Task<List<CategoryResponse>> GetCategories()
        {
            var data = await _ctgRepo.GetCategories();
            return data.Select(c => c.ToCategoryResponse()).ToList();
        }

        public async Task<CategoryResponse?> GetCategoryById(int categoryId)
        {
           var data = await _ctgRepo.GetCategoryById(categoryId);
            return data.ToCategoryResponse();
        }

        public async Task<CategoryResponse> UpdateCategory(CategoryAddRequest ptd)
        {
            var data =await _ctgRepo.UpdateCategory(ptd.ToCategory());
            return data.ToCategoryResponse();
        }
    }
}
