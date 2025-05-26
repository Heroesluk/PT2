using PT2.data.API;
using PT2.logic.API;

namespace PT2.logic
{
    internal class UserService : IUserService
    {
        //private IUserRepository _userRepository;
        private IDataService _dataService;

        public UserService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public void RegisterUser(string username, string password, string email)
        {
            //empty fields check
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Username, password, and email cannot be empty.");

            //user already exists
            if (_dataService.userRepo.GetUserByUsername(username) != null)
                throw new InvalidOperationException("User already exists.");

            var user = new UserDto(-1, username, password, email);
            _dataService.userRepo.AddUser(user);
        }

        //TO DO: implement / rm - this functionality requires some kind of session mechanism
        public void LoginUser(string username, string password)
        {
            throw new NotImplementedException("LoginUser method is not implemented.");
        }

        public void RemoveUser(string username)
        {
            if (!_dataService.userRepo.DeleteUserByUsername(username))
                throw new InvalidOperationException("User not found.");
        }

        public bool IsUserRegistered(string username)
        {
            return _dataService.userRepo.GetUserByUsername(username) != null;
        }

        public IUser FindUser(string username)
        {
            return _dataService.userRepo.GetUserByUsername(username);
        }

    }
}
