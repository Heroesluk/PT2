using Logic;
using PT2.logic.API;

namespace Presentation;

internal class UserPanelViewModel
{
    public event EventHandler ItemsChanged;

    private readonly ICatalogService _catalogService;
    private readonly IEventHistoryService _eventHistoryService;
    private readonly IInventoryService _inventoryService;

    internal class AvailableItemDtoPres
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int AvailableQuantity { get; set; }
    }
    
    
    public UserPanelViewModel(ICatalogService catalogService, IEventHistoryService eventHistoryService,
        IInventoryService inventoryService)
    {
        _catalogService = catalogService;
        _eventHistoryService = eventHistoryService;
        _inventoryService = inventoryService;
        RefreshItems();
    }

    public List<AvailableItemDtoPres> AvailableItems { get; private set; }


    public void BuyItem(int itemId, int quantity)
    {
        var stock = _inventoryService.GetItemStock(itemId);
        if (stock < quantity)
        {
            throw new InvalidOperationException("Not enough items in stock.");
        }

        var item = _catalogService.GetItemById(itemId);

        _inventoryService.RemoveStock(itemId, quantity);
        RefreshItems();
        // Log the purchase event
        _eventHistoryService.AddEvent("BuyItem", 1, $"User {1} bought {quantity} of {item.Name} (ID: {itemId})");
    }

    public void RefreshItems()
    {
        var allItems = _catalogService.GetAllItems();
        AvailableItems = allItems.Select(item => new AvailableItemDtoPres
        {
            ItemId = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            AvailableQuantity = _inventoryService.GetItemStock(item.Id)
        }).Where(x => x.AvailableQuantity > 0).ToList();

        OnItemsChanged();
    }

    protected virtual void OnItemsChanged()
    {
        ItemsChanged?.Invoke(this, EventArgs.Empty);
    }
}
