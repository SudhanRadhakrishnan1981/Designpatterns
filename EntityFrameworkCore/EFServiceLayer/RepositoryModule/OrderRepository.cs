using EFModellayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFServiceLayer.RepositoryModule
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context) { }

        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _dbSet.Where(o => o.Id == userId).ToListAsync();
        }
    }
}
