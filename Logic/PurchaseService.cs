using Logic;
using PT2.data.API;
using PT2.logic.API;

namespace PT2.logic
{
    public class PurchaseService : IPurchaseService
    {
        //private IUserRepository _userRepository;
        //private IItemRepository _itemRepository;
        //private IInventoryStateRepository _inventoryStateRepository;
        //private IEventRepository _eventRepository;

        private IDataService _dataService;

        public PurchaseService(IDataService dataService) {
            _dataService = dataService;
        }

        public void SellItem(int userId, int itemId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            var user = _dataService.userRepo.GetAllUsers().Find(u => u.Id == userId);
            if (user == null)
                throw new InvalidOperationException("User not found.");

            var item = _dataService.itemRepo.GetItem(itemId);
            if (item == null)
                throw new InvalidOperationException("Item not found.");

            var inventory = _dataService.inventoryStateRepo.GetInventoryState(itemId);
            if (inventory == null || inventory.Quantity < quantity)
                throw new InvalidOperationException("Insufficient stock.");

            inventory.Quantity -= quantity;
            _dataService.inventoryStateRepo.UpdateInventoryState(itemId, inventory.Quantity);

            var purchaseEvent = new PurchaseEventDto(
                userId: userId,
                itemId: itemId,
                quantity: quantity,
                timestamp: DateTime.UtcNow
            );
            _dataService.eventRepo.AddEvent(purchaseEvent);
        }

        public float CalculateTotalPrice(int itemId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            var item = _dataService.itemRepo.GetItem(itemId);
            if (item == null)
                throw new InvalidOperationException("Item not found.");

            return item.Price * quantity;
        }
    }
}
