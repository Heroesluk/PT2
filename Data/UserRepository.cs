﻿using PT2.data.API;

namespace PT2.data
{
    internal class UserRepository : IUserRepository
    {
        private readonly IDataContext DataContext;
    
        public UserRepository(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public IUser GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }
            

            return DataContext.Users.First(u => u.Username.Equals(username));
        }

        public List<IUser> GetAllUsers()
        {
            return DataContext.Users.ToList();
        }

        public int AddUser(IUser user)
        {
            //null user protection
            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null");
            }

            //negative user id protection 
            if (user.Id < -1)
            {
                throw new ArgumentException("User id cannot be a negative number. (except -1)");
            }

            //duplicate id protection
            if (
                user.Id != -1 && 
                DataContext.Users != null && 
                DataContext.Users.Any(u => u.Id.Equals(user.Id))
               )
            {
                throw new InvalidOperationException("User with a given id already exists.");
            }

            //duplicate username protection
            if (
                DataContext.Users != null && 
                DataContext.Users.Any(u => u.Username.Equals(user.Username))
               )
            {
                throw new InvalidOperationException($"User with username '{user.Username}' already exists.");
            }

            //auto numbering of IDs (handling of id = -1)
            int newId;

            if (user.Id == -1)
            {
                try
                {
                    //highest ID + 1
                    newId = DataContext.Users.Max(u => u.Id) + 1;
                }
                catch (ArgumentNullException) 
                {
                    //first user
                    newId = 0;
                }
                
                //overwriting ID
                user.Id = newId;
            }

            //user addition
            DataContext.Users.Add(user);

            //TODO: what's that???
            return -1;
        }

        public bool DeleteUserByUsername(string username)
        {
            return DataContext.Users.RemoveAll(u => u.Username.Equals(username)) > 0;
        }
    }
}
