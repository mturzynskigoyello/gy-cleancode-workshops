namespace GyShop.Cli.Users
{
    interface IUserRepository
    {
        void AddUser(string username, string password);
        bool UserExists(string username);
        bool UserExists(string username, string password);
    }
}