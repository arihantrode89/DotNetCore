using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Configuration.Controllers
{
    [Route("api")]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly OptionModel _options;
        public HomeController(IConfiguration Config,IOptions<OptionModel> options) 
        {
            _configuration = Config; //injection configuration into controller
            _options = options.Value; //injection option model
        }
        [Route("keys")]
        public IActionResult Index()
        {
            //ViewData["amz"] = _configuration["AwsConfig:key"];
            
            ViewData["amz"] = _configuration.GetSection("AwsConfig")["key"]; //alternate to above command

            //using injected Ioptions
            //ViewData["AmzOption"] = _options.Key;

            //using injection configuration
            var a = _configuration.GetSection("AwsConfig").Get<OptionModel>();
            OptionModel? obj = new OptionModel();
            _configuration.GetSection("AwsConfig").Bind(obj);
            ViewData["AmzOption"]=a.Key;
            ViewData["AmzOption1"]=obj.Password;
            return View();
        }
    }
}
