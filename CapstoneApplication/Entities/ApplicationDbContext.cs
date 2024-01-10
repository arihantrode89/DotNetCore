using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var data = new Category() { CategoryId=1,CategoryName = "Soap", CategoryDescription = "Diffrent kind of Soap" };
            modelBuilder.Entity<Category>().HasData(data);
            modelBuilder.Entity<Product>().HasData(new Product() {ProductId=1, ProductName="Vim Bar",ProductDescription="Utensils Soap",CurrentPrice=50,CategoryId=1});
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
