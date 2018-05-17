using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyShop.Cli.Orders
{
    class Order
    {
        public string Username { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
