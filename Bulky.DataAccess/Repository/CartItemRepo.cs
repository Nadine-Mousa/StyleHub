using StyleHub.DataAccess.Repository.IRepository;
using StyleHub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StyleHub.DataAccess.Repository
{
    public class CartItemRepo : Repository<CartItem>, ICartItemRepo
    {
        public CartItemRepo(ApplicationDbContext db) : base(db)
        {
        }
    }
}
