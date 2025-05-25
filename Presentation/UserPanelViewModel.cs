using Logic;
using PT2.logic.API;

namespace Presentation;

// UserPanelViewModel.cs
public class UserPanelViewModel
{
    private readonly IInventoryService _inventoryService;
    private readonly ICatalogService _catalogService;
    public event EventHandler ItemsChanged;

    public List<AvailableItemDto> AvailableItems { get; private set; }

    public UserPanelViewModel(IInventoryService inventoryService, ICatalogService catalogService)
    {
        _inventoryService = inventoryService;
        _catalogService = catalogService;
        RefreshItems();
    }

    public void BuyItem(int itemId, int quantity)
    {
        var stock = _inventoryService.GetItemStock(itemId);
        if (stock < quantity)
        {
            throw new InvalidOperationException("Not enough items in stock.");
        }

        _inventoryService.RemoveStock(itemId, quantity);
        RefreshItems();
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