using EFModellayer.Data;
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
        private readonly CustomerPizzaContext _context;
        public ProductRepository(CustomerPizzaContext context) : base(context)
        {
            _context = context;
        }



        public async Task<Product> GetUserWithOrdersAsync(int id)
        {
            return await _context.Set<Product>()
           .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Product.ToListAsync();
        }
    }
}
