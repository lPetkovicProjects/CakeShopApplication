using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CakeShop.Data.Interfaces;
using CakeShop.Data.Models;
using Microsoft.AspNetCore.Authorization;
using CakeShop.ViewModel;

namespace CakeShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICakeRepository cakeRepository;
        private readonly Cart cart;


        public ShoppingCartController(ICakeRepository cakeRepository, Cart cart)
        {
            this.cakeRepository = cakeRepository;
            this.cart = cart;
        }


       
        public ViewResult Index()
        {
            var items = cart.GetShoppingCartItems();
            cart.ShoppingCartItems = items;

            var shoppingCartModel = new SoppingCartModel
            {
                Cart = cart,
                ShoppingCartTotal = cart.GetShoppingCartTotal()
            };
            return View(shoppingCartModel);
        }

        
        public RedirectToActionResult AddToShoppingCart(int cakeId)
        {
            var selectedCake = cakeRepository.Cakes.FirstOrDefault(p => p.CakeId == cakeId);
            if (selectedCake != null)
            {
                cart.AddToCart(selectedCake, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int cakeId)
        {
            var selectedCake = cakeRepository.Cakes.FirstOrDefault(p => p.CakeId == cakeId);
            if (selectedCake != null)
            {
                cart.RemoveFromCart(selectedCake);
            }
            return RedirectToAction("Index");
        }
    }
}