using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CakeShop.Models;
using CakeShop.Data.Interfaces;
using CakeShop.ViewModel;

namespace CakeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICakeRepository cakeRepository;

        public HomeController(ICakeRepository cakeRepository)
        {
            this.cakeRepository = cakeRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                PreferredCakes = cakeRepository.PreferredCake
            };
            return View(homeViewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
