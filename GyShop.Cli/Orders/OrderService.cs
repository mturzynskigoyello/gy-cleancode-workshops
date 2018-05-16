using GyShop.Cli.Products;

namespace GyShop.Cli.Orders
{
    class OrderService : IOrderService
    {
        private readonly IOrderValidator _orderValidator;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderValidator orderValidator, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _orderValidator = orderValidator;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public OrderValidationResult PlaceOrder(Order order)
        {
            var validationResult = _orderValidator.Validate(order);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            foreach (var item in order.Items)
            {
                _productRepository.DecreaseProductQuantity(item.Name, item.Quantity);
            }

            _orderRepository.AddOrder(order);

            return validationResult;
        }
    }
}
