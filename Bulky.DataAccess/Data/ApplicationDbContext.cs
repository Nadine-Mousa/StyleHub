using BookNook.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;



namespace BookNook.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "History", DisplayOrder = 1},
                new Category { Id = 2, Name = "Action", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Science", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductImages)           // One Product has many ProductImages
                .WithOne(pi => pi.Product)              // Each ProductImage belongs to one Product
                .HasForeignKey(pi => pi.ProductId)     // Define the foreign key
                .OnDelete(DeleteBehavior.Cascade);  
        }
    }   
}
