using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyShop.Cli.Orders
{
    class OrderRepository : IOrderRepository
    {
        private static readonly List<Order> _orders = new List<Order>
        {
            new Order
            {
                Username = "maciek",
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Name = "design-patterns",
                        Quantity = 12
                    },
                    new OrderItem
                    {
                        Name = "linq",
                        Quantity = 2
                    }
                }
            }
        };
        
        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orders.ToList();
        }
    }
}
