using CakeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.ViewModel
{
    public class SoppingCartModel
    {

        public Cart Cart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
