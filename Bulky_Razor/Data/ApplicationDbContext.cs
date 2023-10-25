using Bulky_Razor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;

namespace Bulky_Razor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Product> products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new { Id = 1, Title = "Title", Description = "Default description for a book.", ISBN = "123456789012", Author = "Mohammed"},
            new { Id = 2, Title = "Title", Description = "Default description for a book.", ISBN = "123456789012", Author = "Mohammed"},
            new { Id = 3, Title = "Title", Description = "Default description for a book.", ISBN = "123456789012", Author = "Mohammed"}
            );

        }




    }
}
