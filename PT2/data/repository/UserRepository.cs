using System;
using System.Collections.Generic;
using System.Linq;
using PT2.data.interfaces;
using PT2.data.model;

namespace PT2.data.repository
{
    public class UserRepository : IUserRepository
    {

        private List<User> _users = new List<User>();

        public UserRepository() { }

        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }

            return _users.First(u => u.Username.Equals(username));
        }

        public List<User> GetAllUsers()
        {
            return _users.ToList();
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null");
            }

            if (_users.Any(u => u.Username.Equals(user.Username)))
            {
                throw new InvalidOperationException($"User with username '{user.Username}' already exists.");
            }

            _users.Add(user);
        }

        public bool DeleteUserByUsername(string username)
        {
            return _users.RemoveAll(u => u.Username.Equals(username)) > 0;
        }
    }
}
