using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Data.Models
{
    public class Cart
    {
        private readonly CakeDbContext cakeDbContext;
        private Cart(CakeDbContext cakeDbContext)
        {
            this.cakeDbContext = cakeDbContext;
        }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCart> ShoppingCartItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<CakeDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new Cart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Cake cake, int amount)
        {
            var shoppingCartItem =
                    cakeDbContext.ShoppingCarts.SingleOrDefault(
                        s => s.Cake.CakeId == cake.CakeId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCart
                {
                    ShoppingCartId = ShoppingCartId,
                    Cake = cake,
                    Amount = 1
                };

                cakeDbContext.ShoppingCarts.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            cakeDbContext.SaveChanges();
        }

        public int RemoveFromCart(Cake cake)
        {
            var shoppingCartItem =
                    cakeDbContext.ShoppingCarts.SingleOrDefault(
                        s => s.Cake.CakeId == cake.CakeId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    cakeDbContext.ShoppingCarts.Remove(shoppingCartItem);
                }
            }

            cakeDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCart> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       cakeDbContext.ShoppingCarts.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Cake)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = cakeDbContext
                .ShoppingCarts
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            cakeDbContext.ShoppingCarts.RemoveRange(cartItems);

            cakeDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = cakeDbContext.ShoppingCarts.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Cake.Price * c.Amount).Sum();
            return total;
        }
    }
}
