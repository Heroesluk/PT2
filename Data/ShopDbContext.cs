using Data.API;
using Microsoft.EntityFrameworkCore;
using PT2.data;
using PT2.data.API;

namespace Data
{
    internal class ShopDbContext : DbContext, IShopDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<InventoryState> Inventory { get; set; }
        public DbSet<Event> Events { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}