using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory
{
    public class RetailContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RetailInventoryDB;Trusted_Connection=True;");
        }
    }
}
