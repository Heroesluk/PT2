using Microsoft.EntityFrameworkCore;
using PT2.data.API;

namespace PT2.data;

// Data/ShopDbContext.cs
public class ShopDbContext : DbContext
{
    public DbSet<IUser> Users { get; set; }
    public DbSet<IItem> Items { get; set; }
    public DbSet<IInventoryState> Inventory { get; set; }
    public DbSet<IEvent> Events { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=shop.db");
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .HasDiscriminator<string>("EventType")
            .HasValue<PurchaseEvent>("Purchase");
            
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
    }
}