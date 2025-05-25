using Data.API;
using Microsoft.EntityFrameworkCore;
using PT2.data;
using PT2.data.API;

namespace Data
{
    public class InventoryStateDbRepository : IInventoryStateRepository
    {
        private readonly IShopDbContext _dbContext;

        internal InventoryStateDbRepository(IShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddInventoryState(IInventoryState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            if (_dbContext.Inventory.Any(i => i.ItemId == state.ItemId))
                throw new InvalidOperationException("Inventory state for this item already exists.");

            _dbContext.Inventory.Add(new InventoryState(state.ItemId,state.Quantity));
            _dbContext.SaveChanges();
        }

        public IInventoryState GetInventoryState(int itemId)
        {
            return _dbContext.Inventory.FirstOrDefault(i => i.ItemId == itemId);
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
            var state = _dbContext.Inventory.FirstOrDefault(i => i.ItemId == itemId);

            if (state == null)
                throw new InvalidOperationException("Inventory state not found.");

            // Attach the entity to the DbContext if it's not already tracked
            _dbContext.Inventory.Attach(state);

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