using Microsoft.AspNetCore.Mvc;
using Service;

namespace DependencyInjection.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _products;
        private readonly IServiceProvider _serviceProvider;
        public ProductController(IProduct product,IServiceProvider provider)
        { 
            _products = product;
            _serviceProvider = provider;
        }
        [Route("")]
        public IActionResult Index([FromServices] IProduct product)
        {
            //above is example to injection dependency into particular function
            List<string> data = new List<string>();
            using (var abc = _serviceProvider.CreateScope())
            {
                IProduct ser = (IProduct)abc.ServiceProvider.GetService(typeof(IProduct));
                data = ser.Products();
            }
            //return View(product.Products());
            //return View(_products.Products());
            return View(data);
        }
    }
}
