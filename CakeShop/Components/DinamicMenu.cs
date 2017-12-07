using CakeShop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Components
{
    public class DinamicMenu:ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public DinamicMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.Categoryes.OrderBy(p => p.CategoryName);
            return View(categories);
        }
    }
}
