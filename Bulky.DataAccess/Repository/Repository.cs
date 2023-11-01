using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookNook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookNook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext _db;
        private DbSet<T> _dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _db.SaveChanges();
        }

        public T Get(int id)
        {
            T entity = _dbSet.Find(id);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> objects = _dbSet.ToList();
            return objects;
        }

        public void Remove(int id)
        {
            T entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _db.SaveChanges();
            }
        }

        public void Remove(T entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
