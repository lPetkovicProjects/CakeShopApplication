using CakeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.ViewModel
{
    public class CakeList
    {

       public IEnumerable<Cake> Cakes { get; set; }

        public string CurrentCategory { get; set; }
    }
}
