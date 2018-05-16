namespace GyShop.Cli.Users
{
    interface IUserRepository
    {
        void AddUser(string username, string password);
        bool UserExists(string username);
        bool ValidateUser(string username, string password);
    }
}