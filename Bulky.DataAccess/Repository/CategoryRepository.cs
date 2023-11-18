using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookNook.Models;
using BookNook.DataAccess.Repository.IRepository;

namespace BookNook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, IRepositoryCategory
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
