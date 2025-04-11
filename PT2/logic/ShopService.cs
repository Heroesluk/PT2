using System;
using System.Collections.Generic;
using PT2.data.interfaces;
using PT2.data.model;
using PT2.logic.interfaces;

namespace PT2.logic
{
    public class ShopService : IShopService
    {
        private readonly IUserRepository _userRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IInventoryStateRepository _inventoryStateRepository;
        private readonly IEventRepository _eventRepository;

        public ShopService(
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

        // User Management
        public void RegisterUser(string username, string password, string email)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Username, password, and email cannot be empty.");

            if (_userRepository.GetUserByUsername(username) != null)
                throw new InvalidOperationException("User already exists.");

            var user = new User(-1, username, password, email);
            _userRepository.AddUser(user);
        }

        public void RemoveUser(string username)
        {
            if (!_userRepository.DeleteUserByUsername(username))
                throw new InvalidOperationException("User not found.");
        }

        public bool IsUserRegistered(string username)
        {
            return _userRepository.GetUserByUsername(username) != null;
        }

        // Catalog Management
        public void AddItemToCatalog(int itemId, string name, string description, float price)
        {
            if (price < 0)
                throw new ArgumentException("Price cannot be negative.");

            var item = new Item { Id = itemId, Name = name, Description = description, Price = price };
            _itemRepository.AddItem(item);
        }

        public List<Item> GetAllItems()
        {
            return new List<Item>(_itemRepository.GetAllItems());
        }

        public Item GetItemById(int itemId)
        {
            var item = _itemRepository.GetItem(itemId);
            if (item == null)
                throw new InvalidOperationException("Item not found.");
            return item;
        }

        public void UpdateItemDetails(int itemId, string name, string description, float price)
        {
            var item = _itemRepository.GetItem(itemId);
            if (item == null)
                throw new InvalidOperationException("Item not found.");

            item.Name = name;
            item.Description = description;
            item.Price = price;
            _itemRepository.UpdateItem(item);
        }

        public void RemoveItemFromCatalog(int itemId)
        {
            _itemRepository.DeleteItem(itemId);
        }

        // Inventory Management
        public void AddStock(int itemId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            var inventory = _inventoryStateRepository.GetInventoryState(itemId) ?? new InventoryState { ItemId = itemId, Quantity = 0 };
            inventory.Quantity += quantity;
            _inventoryStateRepository.UpdateInventoryState(itemId, inventory.Quantity);
        }

        public int GetItemStock(int itemId)
        {
            var inventory = _inventoryStateRepository.GetInventoryState(itemId);
            return inventory?.Quantity ?? 0;
        }

        public void RemoveStock(int itemId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            var inventory = _inventoryStateRepository.GetInventoryState(itemId);
            if (inventory == null || inventory.Quantity < quantity)
                throw new InvalidOperationException("Insufficient stock.");

            inventory.Quantity -= quantity;
            _inventoryStateRepository.UpdateInventoryState(itemId, inventory.Quantity);
        }

        // Purchase Processing
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

        // Event History
        public List<Event> GetAllPurchaseEvents()
        {
            return _eventRepository.GetAllEvents();
        }

        public List<Event> GetUserPurchaseHistory(int userId)
        {
            return _eventRepository.GetEventsByUserId(userId);
        }

        public List<Event> GetPurchaseEventsByItemId(int itemId)
        {
            return _eventRepository.GetEventsByType("Purchase")
                .FindAll(e => e is PurchaseEvent pe && pe.ItemId == itemId);
        }
    }
}