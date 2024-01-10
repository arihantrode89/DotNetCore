using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {

            _db = db;

        }
        public async Task<Category> AddCategory(Category ptd)
        {
           _db.Category.Add(ptd);
           await _db.SaveChangesAsync();
           return ptd;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _db.Category.ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int categoryId)
        {
            return await _db.Category.FirstOrDefaultAsync(s=>s.CategoryId == categoryId);
        }

        public async Task<Category> UpdateCategory(Category ctg)
        {
            if(ctg == null)
            {
                return ctg;
            }
            var oldObj = await _db.Category.FirstOrDefaultAsync(x=>x.CategoryId == ctg.CategoryId);

            oldObj.CategoryName = ctg.CategoryName;
            oldObj.CategoryDescription = ctg.CategoryDescription;
            await _db.SaveChangesAsync();
            return oldObj;
        }
    }
}
