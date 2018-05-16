using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyShop.Cli.Orders
{
    class OrderSummaryBuilder : IOrderSummaryBuilder
    {
        public string Build(Order order)
        {
            var stringBuilder = new StringBuilder();            
            foreach (var item in order.Items)
            {
                stringBuilder.AppendLine($"{item.Name} with XP {item.Quantity}");
            }
            var totalXp = order.Items.Sum(x => x.Quantity);
            stringBuilder.AppendLine($"Total XP: {totalXp}");
            return stringBuilder.ToString();
        }
    }
}
