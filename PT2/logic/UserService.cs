using System;
using PT2.data.interfaces;
using PT2.data.model;

namespace PT2.logic
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterUser(string username, string password, string email)
        {
            //empty fields check
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Username, password, and email cannot be empty.");

            //user already exists
            if (_userRepository.GetUserByUsername(username) != null)
                throw new InvalidOperationException("User already exists.");

            var user = new User(-1, username, password, email);
            _userRepository.AddUser(user);
        }

        //TO DO: implement / rm - this functionality requires some kind of session mechanism
        public void LoginUser(String username, String password)
        {
            throw new NotImplementedException("LoginUser method is not implemented.");
        }

        public void RemoveUser(string username)
        {
            if (!_userRepository.DeleteUserByUsername(username))
                throw new InvalidOperationException("User not found.");
        }

        public bool IsUserRegistered(string username)
        {
            return _userRepository.GetUserByUsername(username) != null;
        }

        public User FindUser(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

    }
}
