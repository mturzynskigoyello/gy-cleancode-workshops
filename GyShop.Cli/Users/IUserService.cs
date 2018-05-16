namespace GyShop.Cli.Users
{
    interface IUserService
    {
        SignOnResult SignOn(string username, string password);
    }
}