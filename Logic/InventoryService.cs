using Logic;
using PT2.data.API;
using PT2.logic.API;

namespace PT2.logic
{
    internal class InventoryService : IInventoryService
    {
        //private IInventoryStateRepository _inventoryStateRepository;
        private IDataService _dataService;

        public InventoryService(IDataService dataService)
        {
            _dataService = dataService;
        }
        

        public void AddStock(int itemId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            var inventory = _dataService.inventoryStateRepo.GetInventoryState(itemId);
            if (inventory == null)
            {
                inventory = new InventoryStateDto(itemId, quantity);
                _dataService.inventoryStateRepo.AddInventoryState(inventory);
            }
            else
            {
                inventory.Quantity += quantity;
                _dataService.inventoryStateRepo.UpdateInventoryState(itemId, inventory.Quantity);
            }
        }

        public int GetItemStock(int itemId)
        {
            var inventory = _dataService.inventoryStateRepo.GetInventoryState(itemId);
            return inventory?.Quantity ?? 0;
        }

        public void RemoveStock(int itemId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            var inventory = _dataService.inventoryStateRepo.GetInventoryState(itemId);
            if (inventory == null || inventory.Quantity < quantity)
                throw new InvalidOperationException("Insufficient stock.");

            inventory.Quantity -= quantity;
            _dataService.inventoryStateRepo.UpdateInventoryState(itemId, inventory.Quantity);
        }
                
    }
}
