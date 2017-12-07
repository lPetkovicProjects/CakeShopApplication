using CakeShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Data.Models;

namespace CakeShop.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CakeDbContext _appDbContext;
        private readonly Cart _shoppingCart;


        public OrderRepository(CakeDbContext appDbContext, Cart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    CakeId = shoppingCartItem.Cake.CakeId,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Cake.Price
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }
}
