using GyShop.Cli.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyShop.Cli.Orders
{
    class OrderValidator : IOrderValidator
    {
        private readonly IProductRepository _productRepository;

        public OrderValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OrderValidationResult Validate(Order order)
        {
            var notAvailableItems = new List<string>();
            var notExistingItems = new List<string>();

            var groupedItems = order.Items.GroupBy(x => x.Name);
            foreach (var item in groupedItems)
            {
                var product = _productRepository.GetProduct(item.Key);
                if (product == null)
                {
                    notExistingItems.Add(product.Name);
                }
                else if (item.Sum(x => x.Quantity) > product.AvailableQuantity)
                {
                    notAvailableItems.Add(product.Name);
                }
            }

            return new OrderValidationResult
            {
                IsValid = !notAvailableItems.Any() && !notExistingItems.Any(),
                NotAvailableItems = notAvailableItems,
                NotExistingItems = notExistingItems
            };
        }
    }
}
