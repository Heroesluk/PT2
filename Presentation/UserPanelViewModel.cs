using Logic;
using PT2.logic.API;

namespace Presentation;

public class UserPanelViewModel
{
    public event EventHandler ItemsChanged;


    private readonly ICatalogService _catalogService;
    private readonly IEventHistoryService _eventHistoryService;
    private readonly IInventoryService _inventoryService;

    public UserPanelViewModel(ICatalogService catalogService, IEventHistoryService eventHistoryService,
        IInventoryService inventoryService)
    {
        _catalogService = catalogService;
        _eventHistoryService = eventHistoryService;
        _inventoryService = inventoryService;
        RefreshItems();
    }

    public List<AvailableItemDto> AvailableItems { get; private set; }


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
        AvailableItems = allItems.Select(item => new AvailableItemDto
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