using BookNook.DataAccess.Repository.IRepository;
using BookNook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace BookNook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>
    {
        private ProductImage ProductImage { get; set; }
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
    }
}
