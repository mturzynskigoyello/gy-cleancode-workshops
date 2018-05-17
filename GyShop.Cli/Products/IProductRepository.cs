using System.Collections.Generic;

namespace GyShop.Cli.Products
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAvailableProducts();
        Product GetProduct(string name);
        void DecreaseProductQuantity(string name, int decreaseBy);
    }
}
