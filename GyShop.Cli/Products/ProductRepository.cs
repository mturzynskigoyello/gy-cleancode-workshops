using System.Collections.Generic;
using System.Linq;

namespace GyShop.Cli.Products
{
    class ProductRepository : IProductRepository
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product
            {
                Name = "design-patterns",
                AvailableQuantity = 20
            },
            new Product
            {
                Name = "refactoring",
                AvailableQuantity = 1
            },
            new Product
            {
                Name = "SOLID",
                AvailableQuantity = 0
            },
            new Product
            {
                Name = "tdd",
                AvailableQuantity = 80
            },
            new Product
            {
                Name = "linq",
                AvailableQuantity = 5
            }
        };

        public IEnumerable<Product> GetAvailableProducts()
        {
            return _products.Where(x => x.AvailableQuantity > 0).ToList();
        }

        public Product GetProduct(string name)
        {
            return _products.FirstOrDefault(x => x.Name == name);
        }

        public void DecreaseProductQuantity(string name, int decreaseBy)
        {
            var product = GetProduct(name);
            product.AvailableQuantity -= decreaseBy;
        }
    }
}
