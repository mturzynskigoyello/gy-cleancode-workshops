namespace GyShop.Cli.Orders
{
    interface IOrderService
    {
        OrderValidationResult PlaceOrder(Order order);
    }
}