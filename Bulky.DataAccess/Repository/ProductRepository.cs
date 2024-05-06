using StyleHub.DataAccess.Repository.IRepository;
using StyleHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace StyleHub.DataAccess.Repository
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
