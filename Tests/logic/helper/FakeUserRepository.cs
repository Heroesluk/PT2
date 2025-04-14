using PT2.data.API.model;
using PT2.data.API.repository;

namespace Tests.logic.helper;

class FakeUserRepository : IUserRepository
{
    private readonly Dictionary<string, IUser> _users = new Dictionary<string, IUser>();

    public IUser GetUserByUsername(string username)
    {
        _users.TryGetValue(username, out var user);
        return user;
    }

    public List<IUser> GetAllUsers()
    {
        return new List<IUser>(_users.Values);
    }

    public int AddUser(IUser user)
    {
        if (_users.ContainsKey(user.Username))
            throw new InvalidOperationException("User already exists.");
        _users[user.Username] = user;
        return user.Id;
    }

    public bool DeleteUserByUsername(string username)
    {
        return _users.Remove(username);
    }
}