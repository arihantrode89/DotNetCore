using Microsoft.AspNetCore.Mvc;
using ModelBindingAndValidation.Model;

namespace ModelBindingAndValidation.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Index");
        }

        [Route("Binding/{id:int?}")] //binding pref will be Form data > Request Data > Route Data >Query String
        public IActionResult Binding([FromQuery]int? id,string? name,Person p)
        {
            if(!id.HasValue)
            {
                return Content($"id should be present");
            }
            if (String.IsNullOrEmpty(name))
            {
                return Content($"Name should be present");
            }
            return Content($"Id:{id}  Name:{name} -- {p}");
        }
    }
}
