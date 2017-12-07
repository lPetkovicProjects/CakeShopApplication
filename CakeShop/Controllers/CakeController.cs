using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CakeShop.Data.Interfaces;
using CakeShop.ViewModel;
using CakeShop.Data.Models;

namespace CakeShop.Controllers
{
    public class CakeController : Controller
    {
        private readonly ICakeRepository cakeRepository;
        private readonly ICategoryRepository categoryRepoitory;

        public CakeController(ICakeRepository cakeRepository, ICategoryRepository categoryRepository)
        {
            this.cakeRepository = cakeRepository;
            this.categoryRepoitory = categoryRepository;
        }


        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Cake> cakes;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                cakes = cakeRepository.Cakes.OrderBy(p => p.CakeId);
                currentCategory = "All Cakes";
            }
            else
            {
                if (string.Equals("Čokoladne", _category, StringComparison.OrdinalIgnoreCase))
                    cakes = cakeRepository.Cakes.Where(p => p.Category.CategoryName.Equals("Čokoladne")).OrderBy(p => p.Name);
               else if (string.Equals("Voćne", _category, StringComparison.OrdinalIgnoreCase))
                    cakes = cakeRepository.Cakes.Where(p => p.Category.CategoryName.Equals("Voćne")).OrderBy(p => p.Name);
                else
                    cakes = cakeRepository.Cakes.Where(p => p.Category.CategoryName.Equals("Brze")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new CakeList
            {
                Cakes = cakes,
                CurrentCategory = currentCategory
            });
        }
        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Cake> cakes;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                cakes = cakeRepository.Cakes.OrderBy(p => p.CakeId);
            }
            else
            {
                cakes = cakeRepository.Cakes.Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Cake/List.cshtml", new CakeList { Cakes = cakes, CurrentCategory = "All Cakes" });
        }

        public ViewResult Details(int cakeId)
        {
            var cakes = cakeRepository.Cakes.FirstOrDefault(d => d.CakeId == cakeId);
            if (cakes == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(cakes);
        }
    }
}