namespace GyShop.Cli.Orders
{
    interface IOrderValidator
    {
        OrderValidationResult Validate(Order order);
    }
}