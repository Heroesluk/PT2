using Data.API;
using Microsoft.EntityFrameworkCore;
using PT2.data;
using PT2.data.API;

namespace TestDataLayer
{
    internal class TestDbContext : DbContext, IShopDbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User configuration
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            // Item configuration
            modelBuilder.Entity<Item>().HasKey(i => i.Id);

            // InventoryState configuration
            modelBuilder.Entity<InventoryState>().HasKey(i => i.ItemId);

            // Event configuration
            modelBuilder.Entity<Event>().HasKey(e => e.EventId);

            // Configure inheritance for Event types
            modelBuilder.Entity<Event>()
                .HasDiscriminator<string>("EventType")
                .HasValue<PurchaseEvent>("Purchase");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<InventoryState> Inventory { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
