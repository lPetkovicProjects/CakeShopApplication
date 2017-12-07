using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Data.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartItemId { get; set; }
        public Cake Cake { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
