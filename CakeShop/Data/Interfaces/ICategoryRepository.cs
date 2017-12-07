﻿using CakeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categoryes { get; }
    }
}
