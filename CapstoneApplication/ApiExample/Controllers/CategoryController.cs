using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using System.Web.Http;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ApiExample.Controllers
{

    [Route("[controller]")]
    public class CategoryController : ApiController
    {
        //private readonly IProductRepository _prodRepo;
        private readonly IProductService _prodService;
        private readonly ICategoryService _ctgService;
        public CategoryController(IProductService productService, ICategoryService category)
        {
            //_prodRepo = product;
            _prodService = productService;
            _ctgService = category;
        }

        [Route("/")]
        public async Task<IHttpActionResult> GetAllCategories()
        {
            var data = await _ctgService.GetCategories();
            if (data != null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
    }
}
