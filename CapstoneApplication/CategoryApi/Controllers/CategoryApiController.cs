using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace CategoryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryApiController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryApiController(IProductService prod,ICategoryService ctg)
        {
            _categoryService = ctg;
        }

        [HttpGet(Name ="GetCategory")]
        public async Task<List<CategoryResponse>> GetCategories()
        {
            var data = await _categoryService.GetCategories();
            return data;
        }
    }
}
