using Data;
using Microsoft.EntityFrameworkCore;
using PT2.data.API;

namespace PT2.data;

// Data/DataService.cs
public class DbDataService : IDataService
{
    private readonly ShopDbContext _context;
    
    public IUserRepository userRepo { get; }
    public IItemRepository itemRepo { get; }
    public IInventoryStateRepository inventoryStateRepo { get; }
    public IEventRepository eventRepo { get; }
    
    public DbDataService()
    {
        _context = new ShopDbContext(new DbContextOptions<ShopDbContext>());       
        userRepo = new UserDbRepository(_context);
        itemRepo = new ItemDbRepository(_context);
        inventoryStateRepo = new InventoryStateDbRepository(_context);
        eventRepo = new EventDbRepository(_context);
    }
}