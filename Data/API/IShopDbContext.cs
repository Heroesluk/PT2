using Microsoft.EntityFrameworkCore;
using PT2.data;
using PT2.data.API;

namespace Data.API
{
    internal interface IShopDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<InventoryState> Inventory { get; set; }
        DbSet<Event> Events { get; set; }

        int SaveChanges();
    }
}