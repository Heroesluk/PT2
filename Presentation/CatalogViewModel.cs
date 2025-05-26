using Presentation;
using PT2.data.API;
using PT2.logic.API;

public class CatalogViewModel
{
    private readonly ICatalogService _catalogService;
    private readonly IEventHistoryService _eventHistoryService;
    public event EventHandler ItemsChanged;

    public List<IItem> Items { get; private set; }

    public CatalogViewModel(ICatalogService catalogService, IEventHistoryService eventHistoryService)
    {
        _catalogService = catalogService;
        _eventHistoryService = eventHistoryService;
        RefreshItems();
    }

    public void AddItem(int id, string name, string description, float price)
    {
        _catalogService.AddItemToCatalog(id, name, description, price);
        _eventHistoryService.AddEvent("AddItem", 0, $"Item added: {name} (ID: {id})");
        RefreshItems();
    }

    public void RemoveItem(int id)
    {
        var item = Items.FirstOrDefault(i => i.Id == id);
        
        
        
        
        if (item != null)
        {
            // var relatedEvents = _eventHistoryService.GetPurchaseEventsByItemId(id);
            // foreach (var evt in relatedEvents)
            // {
            //     _eventHistoryService.DeleteEvent(evt.EventId);
            // }
            
            
            _catalogService.RemoveItemFromCatalog(id);
            _eventHistoryService.AddEvent("RemoveItem", 0, $"Item removed: {item.Name} (ID: {id})");
            RefreshItems();
        }
    }
    

    private void RefreshItems()
    {
        Items = _catalogService.GetAllItems();
        OnItemsChanged();
        EventService.OnCatalogChanged(); // Add this line

        if (ItemsChanged != null)
        {
            var handler = ItemsChanged;
            if (handler != null)
            {
                if (Application.OpenForms.Count > 0)
                {
                    var form = Application.OpenForms[0];
                    form.Invoke(() => handler(this, EventArgs.Empty));
                }
                else
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
    }
    
    public void UpdateItem(int id, string name, string description, float price)
    {
        _catalogService.UpdateItemDetails(id, name, description, price);
        RefreshItems();
    }

    protected virtual void OnItemsChanged()
    {
        ItemsChanged?.Invoke(this, EventArgs.Empty);
    }
}