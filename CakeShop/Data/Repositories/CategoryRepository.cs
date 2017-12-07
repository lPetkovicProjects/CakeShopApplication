using CakeShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Data.Models;

namespace CakeShop.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CakeDbContext  cakeContext;

        public CategoryRepository(CakeDbContext cakeContext)
        {
            this.cakeContext = cakeContext;
        }

        public IEnumerable<Category> Categoryes
        {
            get
            {
                return cakeContext.Catgoryes;
            }
        }
    }
}
