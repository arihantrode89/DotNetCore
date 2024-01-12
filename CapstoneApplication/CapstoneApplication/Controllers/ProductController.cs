using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using System.Runtime.CompilerServices;

namespace CapstoneApplication.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _prodRepo;
        private readonly IProductService _prodService;
        private readonly ICategoryService _ctgService;
        public ProductController(IProductRepository product,IProductService productService,ICategoryService category)
        {
            _prodRepo = product;
            _prodService = productService;
            _ctgService = category;
        }

        [Route("/")]
        public async Task<IActionResult> ListProducts()
        {
            var data = await _prodService.GetAllProducts();
            return View(data);
        }

        [Route("/AddProduct")]
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            ViewBag.Categories = await _ctgService.GetCategories();
            return View();
        }

        [Route("/AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddRequest ptd)
        {
            if(ModelState.IsValid)
            {
                await _prodService.AddProduct(ptd);
                return RedirectToAction("ListProducts");
            }
            ViewBag.Categories = await _ctgService.GetCategories();
            return View();
        }

        [Route("/UpdateProduct")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int ProductId)
        {
            List<CategoryResponse> category = await _ctgService.GetCategories();
            var ctg = category.Select(x => new SelectListItem() { Value = x.CategoryId.ToString(), Text = x.CategoryName });
            ViewBag.Categories = ctg;
            var data  = await _prodService.GetProductById(ProductId);
            return View(data.ToUpdateRequest());
        }

        [Route("/UpdateProduct")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductUpdateRequest ptd)
        {
            if (ModelState.IsValid)
            {
                var data = await _prodService.UpdateProduct(ptd);
                return RedirectToAction("ListProducts");
            }
            ViewBag.Errors = ModelState.Values.SelectMany(x=>x.Errors).Select(s=>s.ErrorMessage).ToList();
            return View();

        }

        [Route("/DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            bool succ = await _prodService.DeleteProduct(ProductId);
            if(succ)
            {
                return RedirectToAction("ListProducts");
            }
            return RedirectToAction("ListProducts");
        }
    }
}
