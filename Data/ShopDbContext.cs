using Data.API;
using Microsoft.EntityFrameworkCore;
using PT2.data;

namespace Data
{
    internal class ShopDbContext : DbContext, IShopDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<InventoryState> Inventory { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<PurchaseEvent> PurchaseEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringHere");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Item>().HasKey(i => i.Id);
            modelBuilder.Entity<InventoryState>().HasKey(i => i.ItemId);
            modelBuilder.Entity<Event>().HasKey(e => e.EventId);

            modelBuilder.Entity<Event>()
                .HasDiscriminator<string>("EventType")
                .HasValue<PurchaseEvent>("Purchase");

            modelBuilder.Entity<PurchaseEvent>()
                .HasOne<Item>()
                .WithMany()
                .HasForeignKey(pe => pe.ItemId);
        }
    }
}