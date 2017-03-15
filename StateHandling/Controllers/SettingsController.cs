using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StateHandling.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StateHandling.Controllers
{
    public class SettingsController : Controller
    {
        StateManager manager;
        

        public SettingsController(IMemoryCache cache)
        {
            manager = new StateManager(this, cache);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SettingsCreateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // New code using a statemanager
            manager.Email = viewModel.Email;
            manager.CompanyName = viewModel.CompanyName;
            manager.Greeting = "Dina värden har sparats!";

            // Old code:
            //cache.Set("SupportEmail", viewModel.Email);
            //HttpContext.Session.SetString("CompanyName", viewModel.CompanyName);
            //TempData["Message"] = "Dina värden har sparats!";
            return RedirectToAction("Display");
        }

        [HttpGet]
        public IActionResult Display()
        {
            var model = new SettingsDisplayVM()
            {
                CompanyName = manager.CompanyName,
                Greeting = manager.Greeting,
                Email = manager.Email
            };
            return View(model);
        }
    }
}
