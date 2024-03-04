using EbayDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EbayDAL.DB
{
    public class EbayDbContext:DbContext
    {
        //public EbayDbContext(DbContextOptions<EbayDbContext> options)
        //    : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }
        public DbSet<OrderState> OrderStates { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Зв'язок багато до одного між користувачами і місцем розташування користувачів
            modelBuilder.Entity<User>()
                .HasOne(u => u.Location)
                .WithMany()
                .HasForeignKey(u => u.UserLocationId);

            // Зв'язок один до багатьох між користувачами і продуктами (користувач може мати багато продуктів)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Products)
                .WithOne(p => p.Seller)
                .HasForeignKey(p => p.SallerId);

            // Зв'язок один до багатьох між користувачами і замовленнями (користувач може мати багато замовлень)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Order)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            // Зв'язок багато до одного між продуктами і виробниками
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Manufacturer)
                .WithMany()
                .HasForeignKey(p => p.ManufacturerId);

            // Зв'язок багато до одного між продуктами і категоріями
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);

            // Зв'язок один до багатьох між замовленнями і деталями замовлення
            modelBuilder.Entity<CustomerOrder>()
                .HasMany(o => o.Details)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);

            // Зв'язок один до багатьох між станами замовлень і замовленнями
            modelBuilder.Entity<OrderState>()
                .HasMany(os => os.Order)
                .WithOne(o => o.State)
                .HasForeignKey(o => o.OrderStateId);

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        string connectionString = "Server=;Database=myDatabase;User Id=myUsername;Password=myPassword;";

        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}
    }
}
