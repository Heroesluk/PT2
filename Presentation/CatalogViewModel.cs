using Presentation;
using PT2.data.API;
using PT2.logic.API;

public class CatalogViewModel
{
    private readonly ICatalogService _catalogService;
    public event EventHandler ItemsChanged;

    public List<IItem> Items { get; private set; }

    public CatalogViewModel(ICatalogService catalogService)
    {
        _catalogService = catalogService;
        RefreshItems();
    }

    public void AddItem(int id, string name, string description, float price)
    {
        _catalogService.AddItemToCatalog(id, name, description, price);
        RefreshItems();
    }

    public void RemoveItem(int id)
    {
        _catalogService.RemoveItemFromCatalog(id);
        RefreshItems();
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

    protected virtual void OnItemsChanged()
    {
        ItemsChanged?.Invoke(this, EventArgs.Empty);
    }
}