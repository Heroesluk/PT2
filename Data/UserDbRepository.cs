using Data;
using Data.API;
using Microsoft.EntityFrameworkCore;
using PT2.data.API;

namespace PT2.data;

internal class UserDbRepository : IUserRepository
{
    private readonly IShopDbContext _context;
    
    public UserDbRepository(IShopDbContext context)
    {
        _context = context;
    }

    public IUser GetUserByUsername(string username)
    {
        // Query syntax
        var user = (from u in _context.Users
            where u.Username == username
            select u).FirstOrDefault();
                   
        return user;
    }

    public List<IUser> GetAllUsers()
    {
        // Method syntax
        return _context.Users
            .AsNoTracking()
            .ToList<IUser>();
    }

    public int AddUser(IUser user)
    {
        
        _context.Users.Add(new User(user.Id, user.Username, user.Password, user.Email));
        _context.SaveChanges();
        return user.Id;
    }

    public Boolean DeleteUserByUsername(string username)
    { 
        var user = GetUserByUsername(username);
        if (user == null)
            throw new InvalidOperationException("User not found.");

        _context.Users.Remove((User)user);
        _context.SaveChanges();
        return true;
    }
}