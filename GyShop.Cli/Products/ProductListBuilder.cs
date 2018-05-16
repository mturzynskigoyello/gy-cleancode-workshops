using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyShop.Cli.Products
{
    class ProductListBuilder : IProductListBuilder
    {
        private readonly IProductRepository _productRepository;

        public ProductListBuilder(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public string BuildList()
        {
            var products = _productRepository.GetAvailableProducts();
            var listBuilder = new StringBuilder();
            foreach (var item in products)
            {
                listBuilder.AppendLine($"{item.Name} - available XP: {item.AvailableQuantity}");
            }
            return listBuilder.ToString();
        }
    }
}
