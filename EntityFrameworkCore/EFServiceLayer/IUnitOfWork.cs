using EFServiceLayer.RepositoryModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFServiceLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        IProductRepository ProductRepository { get; }

        IOrderRepository OrderRepository { get; }
        void SaveChanges();
    }
}
