using System.Collections.Generic;
using PT2.data.model;



namespace PT2.data.interfaces
{
    public interface IUserRepository
    {
    
        User GetUserByUsername(string username);

        List<User> GetAllUsers();

        void AddUser(User user);

        bool DeleteUserByUsername(string username);

    }
}