using EFModellayer.Data;
using EFServiceLayer.RepositoryModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFServiceLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerPizzaContext _context;
        private readonly IServiceProvider _serviceProvider;
        private Dictionary<Type, object> _repositories;
        private bool _disposed = false;

        public UnitOfWork(CustomerPizzaContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
            _serviceProvider = serviceProvider;
        }
        public IProductRepository ProductRepository => _serviceProvider.GetService<IProductRepository>();

        public IOrderRepository OrderRepository => _serviceProvider.GetService<IOrderRepository>();

        public IEmployees EmployeesRepository => _serviceProvider.GetService<IEmployees>();

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new Repository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
