using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT2.data.interfaces;
using PT2.data.model;
using PT2.logic.interfaces;

namespace PT2.logic.services
{
    public class InventoryService : IInventoryService
    {
        private IInventoryStateRepository _inventoryStateRepository;

        public InventoryService(IInventoryStateRepository inventoryStateRepository)
        {
            _inventoryStateRepository = inventoryStateRepository;
        }

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
                
    }
}
