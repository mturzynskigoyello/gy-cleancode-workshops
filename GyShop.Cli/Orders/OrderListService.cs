using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyShop.Cli.Orders
{
    class OrderListService : IOrderListService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderListService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetOrders().ToList();
        }
    }
}
