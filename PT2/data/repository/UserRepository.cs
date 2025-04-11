using System;
using System.Collections.Generic;
using System.Linq;
using PT2.data.interfaces;
using PT2.data.model;

namespace PT2.data.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataContext DataContext;
    
        public UserRepository(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }
            

            return DataContext.Users.First(u => u.Username.Equals(username));
        }

        public List<User> GetAllUsers()
        {
            return DataContext.Users.ToList();
        }

        
        // TODO: we should check if id exists in db, and if does throw error
        // if it's -1 then don't throw error but replace it with some new id.
        public int AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null");
            }

            if (DataContext.Users.Any(u => u.Username.Equals(user.Username)))
            {
                throw new InvalidOperationException($"User with username '{user.Username}' already exists.");
            }

            DataContext.Users.Add(user);
            return -1;
        }

        public bool DeleteUserByUsername(string username)
        {
            return DataContext.Users.RemoveAll(u => u.Username.Equals(username)) > 0;
        }
    }
}
