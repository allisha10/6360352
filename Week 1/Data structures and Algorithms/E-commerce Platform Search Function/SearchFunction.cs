using System;
using System.Linq;

namespace ECommerceSearch
{
    public class SearchFunction
    {
        public static Product LinearSearch(Product[] products, string key)
        {
            foreach (var product in products)
            {
                if (product.ProductName.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    return product;
                }
            }
            return null;
        }

        public static Product BinarySearch(Product[] products, string key)
        {
            int left = 0, right = products.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int compare = string.Compare(products[mid].ProductName, key, StringComparison.OrdinalIgnoreCase);

                if (compare == 0) return products[mid];
                else if (compare < 0) left = mid + 1;
                else right = mid - 1;
            }

            return null;
        }
    }
}
