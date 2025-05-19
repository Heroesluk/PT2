using PT2.data;
using PT2.data.API;


using Microsoft.EntityFrameworkCore;


namespace PT2.data
{
    internal class ItemDbRepository : IItemRepository
    {
        private readonly ShopDbContext _dbContext;

        public ItemDbRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddItem(IItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (_dbContext.Items.Any(i => i.Id == item.Id))
                throw new InvalidOperationException("Item with the same ID already exists.");

            _dbContext.Items.Add((Item)item);
            _dbContext.SaveChanges();
        }

        public IItem GetItem(int itemId)
        {
            var item = _dbContext.Items
                .FirstOrDefault(i => i.Id == itemId);

            if (item == null)
                throw new InvalidOperationException("Item with this id does not exist");

            return item;
        }

        public IEnumerable<IItem> GetAllItems()
        {
            return _dbContext.Items.AsNoTracking().ToList();
        }

        public void UpdateItem(IItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var existingItem = _dbContext.Items.Find(item.Id);
            if (existingItem == null)
                throw new InvalidOperationException("Item not found.");

            _dbContext.Entry(existingItem).CurrentValues.SetValues(item);
            _dbContext.SaveChanges();
        }

        public void DeleteItem(int itemId)
        {
            var item = _dbContext.Items.Find(itemId);
            if (item == null)
                throw new InvalidOperationException("Item not found.");

            _dbContext.Items.Remove(item);
            _dbContext.SaveChanges();
        }

        public IItem GetItemByName(string name)
        {
            return _dbContext.Items
                .FirstOrDefault(i => i.Name == name);
        }

        public List<IItem> GetItemsByPriceCutOff(float priceCutOff, string upDown)
        {
            return upDown.ToLower() switch
            {
                "up" => _dbContext.Items.Where(i => i.Price >= priceCutOff).ToList<IItem>(),
                "down" => _dbContext.Items.Where(i => i.Price <= priceCutOff).ToList<IItem>(),
                _ => throw new ArgumentException("Invalid value for 'upDown'. Use 'up' or 'down'.")
            };
        }
    }
}