using System;
using System.Linq;

namespace ECommerceSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = {
                new Product(101, "Laptop", "Electronics"),
                new Product(102, "Shoes", "Fashion"),
                new Product(103, "Phone", "Electronics"),
                new Product(104, "T-Shirt", "Fashion"),
                new Product(105, "Watch", "Accessories")
            };

            Console.WriteLine("Linear Search: 'Phone'");
            var result1 = SearchFunction.LinearSearch(products, "Phone");
            Console.WriteLine(result1 != null ? $"Found: {result1}" : "Not Found");

            var sortedProducts = products.OrderBy(p => p.ProductName.ToLower()).ToArray();

            Console.WriteLine("\nBinary Search: 'Phone'");
            var result2 = SearchFunction.BinarySearch(sortedProducts, "Phone");
            Console.WriteLine(result2 != null ? $"Found: {result2}" : "Not Found");
        }
    }
}
