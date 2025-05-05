using PT2.data.API;

namespace PT2.data
{
    internal class InventoryStateRepository : IInventoryStateRepository
    {
        private readonly IDataContext _dataContext;

        public InventoryStateRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddInventoryState(IInventoryState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            if (_dataContext.Inventory.Any(i => i.ItemId == state.ItemId))
                throw new InvalidOperationException("Inventory state for this item already exists.");

            _dataContext.Inventory.Add(state);
        }

        public IInventoryState GetInventoryState(int itemId)
        {
            return _dataContext.Inventory.FirstOrDefault(i => i.ItemId == itemId);
        }

        public void UpdateInventoryState(int itemId, int newQuantity)
        {
            var state = GetInventoryState(itemId);
            if (state == null)
                throw new InvalidOperationException("Inventory state not found.");

            state.Quantity = newQuantity;
        }

        public void RemoveInventoryState(int itemId)
        {
            var state = GetInventoryState(itemId);
            if (state == null)
                throw new InvalidOperationException("Inventory state not found.");

            _dataContext.Inventory.Remove(state);
        }

        public List<IInventoryState> GetAllInventoryStates()
        {
            return _dataContext.Inventory.ToList();
        }
    }
}