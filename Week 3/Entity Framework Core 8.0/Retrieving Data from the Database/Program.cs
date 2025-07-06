using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailStore.Models;

class Program
{
    static async Task Main()
    {
        using var context = new AppDbContext();

        // 1. Retrieve all products
        var products = await context.Products.ToListAsync();
        Console.WriteLine("All Products:");
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - ₹{p.Price}");

        // 2. Find product by ID (e.g., ID = 1)
        var product = await context.Products.FindAsync(1);
        Console.WriteLine($"\nFound by ID: {product?.Name}");

        // 3. FirstOrDefault product where price > 50000
        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"\nExpensive Product: {expensive?.Name}");
    }
}
