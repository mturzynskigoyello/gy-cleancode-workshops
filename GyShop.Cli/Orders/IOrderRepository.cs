using System.Collections.Generic;

namespace GyShop.Cli.Orders
{
    interface IOrderRepository
    {
        void AddOrder(Order order);
        IEnumerable<Order> GetOrders();
    }
}