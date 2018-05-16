using System.Collections.Generic;

namespace GyShop.Cli.Orders
{
    interface IOrderListService
    {
        IEnumerable<Order> GetOrders();
    }
}