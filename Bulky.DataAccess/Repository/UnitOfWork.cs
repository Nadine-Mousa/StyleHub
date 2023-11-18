using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookNook.DataAccess.Repository.IRepository;

namespace BookNook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IRepositoryCategory CategoryRepo { get; private set; }
        public ProductRepository ProductRepo { get; private set; }
        public ProductImageRepository ProductImageRepo { get; private set; }
        
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CategoryRepo = new CategoryRepository(_db);
            ProductRepo = new ProductRepository(_db);
            ProductImageRepo = new ProductImageRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
