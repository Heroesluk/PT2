using System.Collections.Generic;
using PT2.data.API.model;
using PT2.data.model;

namespace PT2.data.API.repository
{
    public interface IUserRepository
    {

        IUser GetUserByUsername(string username);

        List<IUser> GetAllUsers();

        int AddUser(IUser user);

        bool DeleteUserByUsername(string username);

    }
}