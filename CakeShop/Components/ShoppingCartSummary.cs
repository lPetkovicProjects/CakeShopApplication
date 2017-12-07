using CakeShop.Data.Models;
using CakeShop.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly Cart cart;

        public ShoppingCartSummary(Cart cart)
        {
            this.cart = cart;
        }

        public IViewComponentResult Invoke()
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
    }
}
