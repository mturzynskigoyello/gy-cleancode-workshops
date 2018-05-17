namespace GyShop.Cli.Users
{
    interface IPasswordValidator
    {
        bool IsValid(string password);
    }
}
