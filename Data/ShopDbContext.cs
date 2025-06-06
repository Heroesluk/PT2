using Data.API;
using Microsoft.EntityFrameworkCore;
using PT2.data;
using System;

namespace Data
{
    internal class ShopDbContext : DbContext, IShopDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<InventoryState> Inventory { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<PurchaseEvent> PurchaseEvents { get; set; }
        private bool _initialized;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var baseDirectory = AppContext.BaseDirectory;
            var projectRoot = Path.GetFullPath(Path.Combine(baseDirectory, "..", "..", "..", ".."));
            var envPath = Path.Combine(projectRoot, ".env");
            DotNetEnv.Env.Load(envPath);

            var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("DATABASE_CONNECTION_STRING is not set in the .env file.");
            }

            optionsBuilder.UseSqlite(connectionString).LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships
            modelBuilder.Entity<Item>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<InventoryState>()
                .HasKey(i => i.ItemId);

            modelBuilder.Entity<InventoryState>()
                .HasOne(i => i.Item)
                .WithOne()
                .HasForeignKey<InventoryState>(i => i.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>()
                .HasKey(e => e.EventId);

            modelBuilder.Entity<Event>()
                .HasDiscriminator<string>("EventName")
                .HasValue<PurchaseEvent>("Purchase");

            modelBuilder.Entity<PurchaseEvent>()
                .HasOne<Item>()
                .WithMany()
                .HasForeignKey(pe => pe.ItemId);
        }


        public void EnsureSchemaCreated()
        {
            if (!_initialized)
            {
                if (!Database.CanConnect())
                {
                    Database.EnsureCreated();

                    var baseDirectory = AppContext.BaseDirectory;
                    var projectRoot = Path.GetFullPath(Path.Combine(baseDirectory, "..", "..", "..", ".."));
                    var schemaPath = Path.Combine(projectRoot, "schema.sql");

                    if (!File.Exists(schemaPath))
                    {
                        throw new FileNotFoundException($"Schema file not found at path: {schemaPath}");
                    }

                    var sql = File.ReadAllText(schemaPath);
                    Database.ExecuteSqlRaw(sql);
                }

                _initialized = true;
            }
        }
    }
}
