namespace PT2.data.API
{
    public interface IUserRepository
    {

        IUser GetUserByUsername(string username);

        List<IUser> GetAllUsers();

        int AddUser(IUser user);

        bool DeleteUserByUsername(string username);

    }
}