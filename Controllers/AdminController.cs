using System;
using Microsoft.AspNetCore.Mvc;
using CarsCatalog.Models;

namespace CarsCatalog.Controllers
{
    public class AdminController : Controller
    {
        public AdminController()
        {
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }
    }
}
