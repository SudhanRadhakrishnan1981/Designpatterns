using EFModellayer.Models;
using Microsoft.EntityFrameworkCore;

namespace EFModellayer.Data
{
    public class CustomerPizzaContext :DbContext
    {

        // Add this constructor to your DbContext
        public CustomerPizzaContext(DbContextOptions<CustomerPizzaContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderDeatil> OrderDeatil { get; set; }

        public DbSet<Country> country { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-I4947D8J\\SQLEXPRESS;Initial Catalog=EF_DB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        }
        */
    }
}
