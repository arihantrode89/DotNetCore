using Microsoft.AspNetCore.Mvc;
using StockServiceHttpClient.Models;
using StockServiceHttpClient.StockService;

namespace StockServiceHttpClient.Controllers
{
    [Route("api/v1")]
    public class HomeController : Controller
    {
        private readonly IStock _stock;
        public HomeController(IStock stock) 
        {
            _stock = stock;
        }
        [Route("Symbol")]
        public async Task<IActionResult> Symbol()
        {
            List<StockSymbol> data = await _stock.GetStockSymbol();

            return PartialView(data);
        }

        [Route("Stock")]
        public async Task<IActionResult> Index()
        {
            StockModel data = await _stock.GetStockReport(HttpContext.Request.Query["stock"]!);

            return View(data);
        }
    }
}
