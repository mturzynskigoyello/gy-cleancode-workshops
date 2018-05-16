using GyShop.Cli.Orders;
using GyShop.Cli.Products;
using GyShop.Cli.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyShop.Cli
{
    class Program
    {
        private static readonly IUserService _userService = new UserService(new UserRepository(), new PasswordValidator());
        private static readonly IProductListBuilder _productListBuilder = new ProductListBuilder(new ProductRepository());
        private static readonly IOrderService _orderService = new OrderService(new OrderValidator(new ProductRepository()), new ProductRepository(), new OrderRepository());
        private static readonly IOrderSummaryBuilder _orderSummaryBuilder = new OrderSummaryBuilder();
        private static readonly IOrderListService _orderListService = new OrderListService(new OrderRepository());

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Goyello CleanCode Workshops Shop");
            Console.WriteLine("You can order extraordinary skills which will make your code looks cool!");

            Console.WriteLine("Please enter your username:");
            var username = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            var password = Console.ReadLine();

            var signOnResult = _userService.SignOn(username, password);
            switch (signOnResult)
            {
                case SignOnResult.IncorrectPassword:
                    Console.WriteLine("Incorrect password");
                    Close();
                    return;
                case SignOnResult.InvalidPassword:
                    Console.WriteLine("Invalid password");
                    Close();
                    return;
                case SignOnResult.UsernameInUse:
                    Console.WriteLine("Username already in use");
                    Close();
                    return;
                case SignOnResult.UserCreated:
                    Console.WriteLine("User created");
                    break;
                case SignOnResult.UserFound:
                    break;
            };

            var productList = _productListBuilder.BuildList();
            Console.WriteLine("You may order following items");
            Console.Write(productList);

            var orderItems = GetOrderItems().ToList();
            var order = new Order
            {
                Username = username,
                Items = orderItems
            };
            var validatinResult = _orderService.PlaceOrder(order);
            if (!validatinResult.IsValid)
            {
                if (validatinResult.NotAvailableItems.Any())
                {
                    PrintInvalidItems(validatinResult);
                }
                if (validatinResult.NotExistingItems.Any())
                {
                    PrintNotExistingItems(validatinResult);
                }
                Close();
                return;
            }

            var orderSummary = _orderSummaryBuilder.Build(order);
            Console.WriteLine($"Congratzz {order.Username}, you just ordered:");
            Console.WriteLine(orderSummary);

            Console.WriteLine("All orders in queue:");
            var orders = _orderListService.GetOrders().ToList();
            var summaries = orders.Select(x => _orderSummaryBuilder.Build(x));
            foreach (var summary in summaries)
            {
                Console.WriteLine("Order:");
                Console.WriteLine(summary);
            }

            Close();
        }

        private static void PrintNotExistingItems(OrderValidationResult validatinResult)
        {
            Console.WriteLine("The order is invalid. Some items do not exist:");
            Console.WriteLine(string.Join(", ", validatinResult.NotExistingItems));
        }

        private static void PrintInvalidItems(OrderValidationResult validatinResult)
        {
            Console.WriteLine("The order is invalid. Some items are no longer available:");
            Console.WriteLine(string.Join(", ", validatinResult.NotAvailableItems));
        }

        private static void Close()
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private static IEnumerable<OrderItem> GetOrderItems()
        {
            string itemName = string.Empty;
            do
            {
                Console.WriteLine("Select an item");
                itemName = Console.ReadLine();
                if (itemName != string.Empty)
                {
                    Console.WriteLine("Select XP");
                    if (int.TryParse(Console.ReadLine(), out var xp))
                    {
                        var item = new OrderItem
                        {
                            Name = itemName,
                            Quantity = xp

                        };
                        yield return item;
                    }

                }
            } while (!string.IsNullOrEmpty(itemName));
        }
    }
}