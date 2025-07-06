using System;
using System.Linq;
using RetailStore.Models;

class Program
{
    static void Main()
    {
        using var context = new AppDbContext();

        // Seed data
        if (!context.Categories.Any())
        {
            var electronics = new Category
            {
                Name = "Electronics",
                Products = new List<Product>
                {
                    new Product { Name = "Smartphone", Price = 25000 }
                }
            };

            context.Categories.Add(electronics);
            context.SaveChanges();
        }

        // Display data
        foreach (var product in context.Products)
        {
            Console.WriteLine($"Product: {product.Name}, ₹{product.Price}");
        }
    }
}
