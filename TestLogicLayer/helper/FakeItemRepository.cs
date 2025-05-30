using PT2.data.API;

namespace Tests.logic.helper;

class FakeItemRepository : IItemRepository
{
    private readonly Dictionary<int, IItem> _items = new Dictionary<int, IItem>();

    public void AddItem(IItem item) => _items[item.Id] = item;

    public IItem GetItem(int itemId) => _items.TryGetValue(itemId, out var item) ? item : null;

    public IEnumerable<IItem> GetAllItems() => _items.Values;

    public void UpdateItem(IItem item) => _items[item.Id] = item;

    public void DeleteItem(int itemId) => _items.Remove(itemId);

    public IItem GetItemByName(string name)
    {
        return null;
    }

    public List<IItem> GetItemsByPriceCutOff(float priceCutOff, string upDown)
    {
        return null;
    }
}
