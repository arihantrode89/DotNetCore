using Microsoft.AspNetCore.Mvc;
using ModelBindingAndValidation.Model;

namespace ModelBindingAndValidation.Validation
{
    public class ValidationController : Controller
    {
        [Route("Validation")]
        public IActionResult Index(Person p, [FromHeader] string UserAgent)
        {
            if(!ModelState.IsValid)
            {
                List<string> error = ModelState.Values.SelectMany(x=>x.Errors).Select(x=>x.ErrorMessage).ToList();
                string msg = String.Join("\n", error);
                return Content(msg);
            }
            return Content($"{p}");
        }
    }
}
