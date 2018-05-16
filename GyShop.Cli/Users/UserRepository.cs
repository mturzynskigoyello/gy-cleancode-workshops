using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyShop.Cli.Users
{
    class UserRepository : IUserRepository
    {
        private static Dictionary<string, string> _users = new Dictionary<string, string>
        {
            ["mateusz"] = "123456",
            ["maciek"] = "123456"
        };

        public bool UserExists(string username)
        {
            return _users.ContainsKey(username);
        }

        public bool ValidateUser(string username, string password)
        {
            return _users.TryGetValue(username, out var userPassword) && userPassword == password;
        }

        public void AddUser(string username, string password)
        {
            _users.Add(username, password);
        }
    }
}
