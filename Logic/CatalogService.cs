using PT2.data.API;
using PT2.logic.API;

namespace PT2.logic
{
    public class CatalogService : ICatalogService
    {
        private readonly IDataService _dataService;
        private readonly IInventoryService _inventoryService;

        public CatalogService(IDataService dataService, IInventoryService inventoryService)
        {
            _dataService = dataService;
            _inventoryService = inventoryService;
        }

        public void AddItemToCatalog(int itemId, string name, string description, float price)
        {
            if (price < 0)
                throw new ArgumentException("Price cannot be negative.");

            var item = new ItemDto(itemId, name, description, price);
            _dataService.itemRepo.AddItem(item);

            _inventoryService.AddStock(itemId, 10);
        }

        public List<IItem> GetAllItems()
        {
            return new List<IItem>(_dataService.itemRepo.GetAllItems());
        }

        public IItem GetItemById(int itemId)
        {
            var item = _dataService.itemRepo.GetItem(itemId);
            if (item == null)
                throw new InvalidOperationException("Item not found.");
            return item;
        }

        public void UpdateItemDetails(int itemId, string name, string description, float price)
        {
            var item = _dataService.itemRepo.GetItem(itemId);
            if (item == null)
                throw new InvalidOperationException("Item not found.");

            item.Name = name;
            item.Description = description;
            item.Price = price;
            _dataService.itemRepo.UpdateItem(item);
        }

        public void RemoveItemFromCatalog(int itemId)
        {
            _dataService.itemRepo.DeleteItem(itemId);
            
        }
    }
}