using EFModellayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFServiceLayer.RepositoryModule
{
    public  interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetUserWithOrdersAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
