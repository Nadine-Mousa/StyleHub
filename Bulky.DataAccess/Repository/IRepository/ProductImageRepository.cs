﻿using StyleHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleHub.DataAccess.Repository.IRepository
{
    public class ProductImageRepository : Repository<ProductImage>
    {
        public ProductImageRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
