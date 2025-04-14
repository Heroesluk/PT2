using System;
using PT2.data.API.repository;
using PT2.data.model;
using PT2.logic.interfaces;

namespace PT2.logic.services
{
    public class PurchaseService : IPurchaseService
    {
        private IUserRepository _userRepository;
        private IItemRepository _itemRepository;
        private IInventoryStateRepository _inventoryStateRepository;
        private IEventRepository _eventRepository;

        public PurchaseService(
            IUserRepository userRepository,
            IItemRepository itemRepository,
            IInventoryStateRepository inventoryStateRepository,
            IEventRepository eventRepository)
        {
            _userRepository = userRepository;
            _itemRepository = itemRepository;
            _inventoryStateRepository = inventoryStateRepository;
            _eventRepository = eventRepository;
        }

        public void SellItem(int userId, int itemId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            var user = _userRepository.GetAllUsers().Find(u => u.Id == userId);
            if (user == null)
                throw new InvalidOperationException("User not found.");

            var item = _itemRepository.GetItem(itemId);
            if (item == null)
                throw new InvalidOperationException("Item not found.");

            var inventory = _inventoryStateRepository.GetInventoryState(itemId);
            if (inventory == null || inventory.Quantity < quantity)
                throw new InvalidOperationException("Insufficient stock.");

            inventory.Quantity -= quantity;
            _inventoryStateRepository.UpdateInventoryState(itemId, inventory.Quantity);

            var purchaseEvent = new PurchaseEvent
            {
                UserId = userId,
                ItemId = itemId,
                Quantity = quantity,
                Timestamp = DateTime.UtcNow
            };
            _eventRepository.AddEvent(purchaseEvent);
        }

        public float CalculateTotalPrice(int itemId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            var item = _itemRepository.GetItem(itemId);
            if (item == null)
                throw new InvalidOperationException("Item not found.");

            return item.Price * quantity;
        }
    }
}
