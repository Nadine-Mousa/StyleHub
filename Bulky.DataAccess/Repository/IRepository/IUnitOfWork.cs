using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleHub.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public IRepositoryCategory CategoryRepo { get; }
        public ProductRepository ProductRepo { get; }
        public ProductImageRepository ProductImageRepo { get; }
        public ICartItemRepo CartItemRepo { get; }
        public ICartRepository CartRepo { get; }
        public void Save();
    }
}
