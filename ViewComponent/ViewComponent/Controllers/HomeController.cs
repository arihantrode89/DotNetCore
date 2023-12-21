using Microsoft.AspNetCore.Mvc;
using ViewComponentExample.Models;

namespace ViewComponentExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/details")]
        public IActionResult Details()
        {
            var obj = new List<Person>()
            {
                new Person() {PersonName="Arihant",Email="arihantrode89@gmail.com",Gender=PersonGender.Male},
                new Person() {PersonName="Aditya",Email="aditya89@gmail.com",Gender=PersonGender.Female},
                new Person() {PersonName="Nothing",Email="nothing@gmail.com",Gender=PersonGender.Other},
            };
            return ViewComponent("Grid", new {grid =obj} );
        }
    }
}
