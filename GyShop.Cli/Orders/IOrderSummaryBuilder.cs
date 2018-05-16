namespace GyShop.Cli.Orders
{
    interface IOrderSummaryBuilder
    {
        string Build(Order order);
    }
}