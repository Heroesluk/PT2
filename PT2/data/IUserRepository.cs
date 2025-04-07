using System.Collections.Generic;

namespace PT2.data
{
    public interface IUserRepository
    {
    
        User GetUserByUsername(string username);

        List<User> GetAllUsers();

        void AddUser(User user);

        bool DeleteUserByUsername(string username);

    }
}