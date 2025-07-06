using System;
using System.Threading.Tasks;
using RetailStore.Models;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        // Create categories
        var electronics = new Category { Name = "Electronics" };
        var groceries = new Category { Name = "Groceries" };

        // Insert categories asynchronously
        await context.Categories.AddRangeAsync(electronics, groceries);

        // Create products linked to categories
        var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
        var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

        // Insert products asynchronously
        await context.Products.AddRangeAsync(product1, product2);

        // Save changes
        await context.SaveChangesAsync();

        Console.WriteLine("Initial data inserted successfully!");
    }
}
