using Microsoft.EntityFrameworkCore;
using PT2.data;
using PT2.data.API;

namespace Data
{
    public class InventoryStateDbRepository : IInventoryStateRepository
    {
        private readonly ShopDbContext _dbContext;

        internal InventoryStateDbRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddInventoryState(IInventoryState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            if (_dbContext.Inventory.Any(i => i.ItemId == state.ItemId))
                throw new InvalidOperationException("Inventory state for this item already exists.");

            _dbContext.Inventory.Add((InventoryState)state);
            _dbContext.SaveChanges();
        }

        public IInventoryState GetInventoryState(int itemId)
        {
            var state = _dbContext.Inventory.FirstOrDefault(i => i.ItemId == itemId);
            return state ?? new InventoryState { ItemId = itemId, Quantity = 0 };
        }

        public void UpdateInventoryState(int itemId, int newQuantity)
        {
            var state = _dbContext.Inventory
                .FirstOrDefault(i => i.ItemId == itemId);

            if (state == null)
                throw new InvalidOperationException("Inventory state not found.");

            state.Quantity = newQuantity;
            _dbContext.SaveChanges();
        }

        public void RemoveInventoryState(int itemId)
        {
            var state = _dbContext.Inventory
                .FirstOrDefault(i => i.ItemId == itemId);

            if (state == null)
                throw new InvalidOperationException("Inventory state not found.");

            _dbContext.Inventory.Remove(state);
            _dbContext.SaveChanges();
        }

        public List<IInventoryState> GetAllInventoryStates()
        {
            return _dbContext.Inventory
                .AsNoTracking()
                .ToList<IInventoryState>();
        }
    }
}