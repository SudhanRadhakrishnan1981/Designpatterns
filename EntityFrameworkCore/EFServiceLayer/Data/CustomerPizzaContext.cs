using EFModellayer.Models;
using Microsoft.EntityFrameworkCore;

namespace EFModellayer.Data
{
    public partial  class CustomerPizzaContext : DbContext
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

        public virtual DbSet<Employee>? Employees { get; set; }
        public virtual DbSet<UserInfo>? UserInfos { get; set; }

        public DbSet<Country> country { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-I4947D8J\\SQLEXPRESS;Initial Catalog=EF_DB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.CreatedDate).IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");
                entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");
                entity.Property(e => e.NationalIDNumber).HasMaxLength(15).IsUnicode(false);
                entity.Property(e => e.EmployeeName).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.LoginID).HasMaxLength(256).IsUnicode(false);
                entity.Property(e => e.JobTitle).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.BirthDate).IsUnicode(false);
                entity.Property(e => e.MaritalStatus).HasMaxLength(1).IsUnicode(false);
                entity.Property(e => e.Gender).HasMaxLength(1).IsUnicode(false);
                entity.Property(e => e.HireDate).IsUnicode(false);
                entity.Property(e => e.VacationHours).IsUnicode(false);
                entity.Property(e => e.SickLeaveHours).IsUnicode(false);
                entity.Property(e => e.RowGuid).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.ModifiedDate).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
