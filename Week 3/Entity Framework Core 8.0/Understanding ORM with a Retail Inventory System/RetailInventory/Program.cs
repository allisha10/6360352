using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace RetailInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new RetailContext())
            {
                // Add sample category if none exist
                if (!context.Categories.Any())
                {
                    var electronics = new Category { Name = "Electronics", Products = new List<Product>() };

                    var product = new Product
                    {
                        Name = "Smartphone",
                        Price = 25000,
                        Category = electronics,
                        Stock = new Stock { Quantity = 50 }
                    };

                    electronics.Products.Add(product);
                    context.Categories.Add(electronics);
                    context.SaveChanges();
                }

                // Print all products
                Console.WriteLine("Retail Inventory System started successfully!");
                Console.WriteLine("Product List:");
                foreach (var product in context.Products.Include(p => p.Category).Include(p => p.Stock))
                {
                    Console.WriteLine($"- {product.Name} ({product.Category.Name}): ₹{product.Price}, Stock: {product.Stock.Quantity}");
                }
            }
        }
    }
}
