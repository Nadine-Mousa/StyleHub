using StyleHub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StyleHub.DataAccess.Repository.IRepository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
