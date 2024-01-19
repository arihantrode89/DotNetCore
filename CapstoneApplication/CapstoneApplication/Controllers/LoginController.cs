using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapstoneApplication.Controllers
{
    [Route("[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly UserManager<PersonIdentity> _userManager;
        private readonly SignInManager<PersonIdentity> _signInManager;

        public LoginController(UserManager<PersonIdentity> user, SignInManager<PersonIdentity> signInManager)
        {
            _userManager = user;
            _signInManager = signInManager;

        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(PersonRegister person)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = ModelState.Values.SelectMany(x=>x.Errors).Select(c=>c.ErrorMessage).ToList();
                return View(person);
            }
            var pp = new PersonIdentity() { PersonName = person.Name ,Email=person.Email,UserName=person.Email};
            var result = await _userManager.CreateAsync(pp, person.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(pp, isPersistent: false);
                return RedirectToAction("ListProducts", "Product");
            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("Register", error.Description);
            }
            return View(person);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO data) 
        { 
            if(!ModelState.IsValid)
            {
                ViewBag.Error = ModelState.Values.SelectMany(x => x.Errors).Select(c => c.ErrorMessage).ToList();
                return View(data);
            }
            var identity = new PersonIdentity() { UserName=data.UserName ,Email=data.UserName};

            var logged = await _signInManager.PasswordSignInAsync(data.UserName, data.Password,isPersistent:data.KeepSignIn,lockoutOnFailure:false);
            if(logged.Succeeded)
            {
                return RedirectToAction("ListProducts", "Product");
            }

            ModelState.AddModelError("Login", "Invalid Email or password");
            return View(data);
        }
    }
}
