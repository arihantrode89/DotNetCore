﻿using Microsoft.AspNetCore.Mvc;

namespace CapstoneApplication.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
