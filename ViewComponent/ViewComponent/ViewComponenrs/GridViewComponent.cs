using Microsoft.AspNetCore.Mvc;
using ViewComponentExample.Models;

namespace ViewComponentExample.ViewComponenrs
{
    public class GridViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(List<Person> grid)
        {
            //var obj = new List<Person>()
            //{
            //    new Person() {PersonName="Arihant",Email="arihantrode89@gmail.com",Gender=PersonGender.Male},
            //    new Person() {PersonName="Aditya",Email="aditya89@gmail.com",Gender=PersonGender.Female},
            //    new Person() {PersonName="Nothing",Email="nothing@gmail.com",Gender=PersonGender.Other},
            //};
            //ViewData["person"] = obj;
            return View(grid);
        }
    }
}
