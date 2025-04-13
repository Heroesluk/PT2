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
    public class CatalogService : ICatalogService
    {
        private IItemRepository _itemRepository;

        public CatalogService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

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

    }
}
