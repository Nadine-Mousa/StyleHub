using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StyleHub.Models;
using StyleHub.DataAccess.Repository.IRepository;

namespace StyleHub.DataAccess.Repository
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
