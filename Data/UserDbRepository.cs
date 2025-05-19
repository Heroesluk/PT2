using Microsoft.EntityFrameworkCore;
using PT2.data.API;

namespace PT2.data;

internal class UserDbRepository : IUserRepository
{
    private readonly ShopDbContext _context;
    
    public UserDbRepository(ShopDbContext context)
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
        
        _context.Users.Add(user);
        _context.SaveChanges();
        return user.Id;
    }

    public Boolean DeleteUserByUsername(string username)
    { 
        _context.Users.Remove(GetUserByUsername(username));
        return true;
    }
}