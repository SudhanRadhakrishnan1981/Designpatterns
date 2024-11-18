using EFModellayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFServiceLayer.RepositoryModule
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }

        public async Task<Product> GetUserWithOrdersAsync(int id)
        {
            return await _context.Set<Product>()
           .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
