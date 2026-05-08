using DemoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // ====== BẢNG ======
        public DbSet<Student> Students { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Import> Imports { get; set; }
        public DbSet<ImportDetail> ImportDetails { get; set; }

        public DbSet<Export> Exports { get; set; }
        public DbSet<ExportDetail> ExportDetails { get; set; }

        // ====== RELATION ======
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===== ORDER =====

            // Customer - Order (1-n)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Order - OrderDetail (1-n)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            // Product - OrderDetail (1-n)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);

            // ===== PRODUCT =====

            // Category - Product (1-n)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // ===== IMPORT =====

            // Supplier - Import (1-n)
            modelBuilder.Entity<Import>()
                .HasOne(i => i.Supplier)
                .WithMany(s => s.Imports)
                .HasForeignKey(i => i.SupplierId);

            // Import - ImportDetail (1-n)
            modelBuilder.Entity<ImportDetail>()
                .HasOne(id => id.Import)
                .WithMany(i => i.ImportDetails)
                .HasForeignKey(id => id.ImportId);

            // Product - ImportDetail (1-n)
            modelBuilder.Entity<ImportDetail>()
                .HasOne(id => id.Product)
                .WithMany()
                .HasForeignKey(id => id.ProductId);

            // ===== EXPORT =====

            // Export - ExportDetail (1-n)
            modelBuilder.Entity<ExportDetail>()
                .HasOne(ed => ed.Export)
                .WithMany(e => e.ExportDetails)
                .HasForeignKey(ed => ed.ExportId);

            // Product - ExportDetail (1-n)
            modelBuilder.Entity<ExportDetail>()
                .HasOne(ed => ed.Product)
                .WithMany()
                .HasForeignKey(ed => ed.ProductId);
        }
    }
}