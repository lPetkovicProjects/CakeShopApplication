using CakeShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CakeShop.Data.Repositories
{
    public class CakeRepository : ICakeRepository
    {

        private readonly CakeDbContext cakeContext;

        public CakeRepository(CakeDbContext cakeContext)
        {
            this.cakeContext = cakeContext;
        }

        public IEnumerable<Cake> Cakes
        {
            get
            {
                return cakeContext.Cakes.Include(x => x.Category);
            }
        }

        public IEnumerable<Cake> PreferredCake
        {
            get
            {
                return cakeContext.Cakes.Where(x => x.IsPerferedCake).Include(c => c.Category);
            }
        }
           

        public Cake GetCakeById(int cakeId)
        {
            return cakeContext.Cakes.FirstOrDefault(x => x.CakeId == cakeId);
        }
    }
}
