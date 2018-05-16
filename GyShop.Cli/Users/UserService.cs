namespace GyShop.Cli.Users
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordValidator _passwordValidator;

        public UserService(IUserRepository userRepository, IPasswordValidator passwordValidator)
        {
            _userRepository = userRepository;
            _passwordValidator = passwordValidator;
        }

        public SignOnResult SignOn(string username, string password)
        {
            if (_userRepository.UserExists(username, password))
            {
                return SignOnResult.UserFound;
            }
            if (_userRepository.UserExists(username))
            {
                return SignOnResult.UsernameInUse;
            }
            if (!_passwordValidator.IsValid(password))
            {
                return SignOnResult.InvalidPassword;
            }
            _userRepository.AddUser(username, password);
            return SignOnResult.UserCreated;
        }
    }
}
