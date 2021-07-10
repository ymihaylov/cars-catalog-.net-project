using System;
using Microsoft.AspNetCore.Mvc;
using CarsCatalog.Models;
using System.Threading.Tasks;

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

        [HttpGet]
        public IActionResult CarModels()
        {
            return View("~/Views/Home/CarModels");
        }
    }
}
