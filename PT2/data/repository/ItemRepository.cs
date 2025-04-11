using System;
using System.Collections.Generic;
using System.Linq;
using PT2.data.interfaces;
using PT2.data.model;

namespace PT2.data.repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly IDataContext _dataContext;

        public ItemRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (_dataContext.ItemsCatalog.ContainsKey(item.Id))
                throw new InvalidOperationException("Item with the same ID already exists.");

            _dataContext.ItemsCatalog[item.Id] = item;
        }

        public Item GetItem(int itemId)
        {
            if (_dataContext.ItemsCatalog.ContainsKey(itemId))
            {
                return _dataContext.ItemsCatalog[itemId];
            };
            throw new InvalidOperationException("Item with this id does not exist");
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _dataContext.ItemsCatalog.Values;
        }

        public void UpdateItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (!_dataContext.ItemsCatalog.ContainsKey(item.Id))
                throw new InvalidOperationException("Item not found.");

            _dataContext.ItemsCatalog[item.Id] = item;
        }

        public void DeleteItem(int itemId)
        {
            if (!_dataContext.ItemsCatalog.Remove(itemId))
                throw new InvalidOperationException("Item not found.");
        }

        public Item GetItemByName(string name)
        {
            return _dataContext.ItemsCatalog.Values.FirstOrDefault(i => i.Name == name);
        }

        public List<Item> GetItemsByPriceCutOff(float priceCutOff, string upDown)
        {
            return upDown.ToLower() switch
            {
                "up" => _dataContext.ItemsCatalog.Values.Where(i => i.Price >= priceCutOff).ToList(),
                "down" => _dataContext.ItemsCatalog.Values.Where(i => i.Price <= priceCutOff).ToList(),
                _ => throw new ArgumentException("Invalid value for 'upDown'. Use 'up' or 'down'.")
            };
        }
    }
}