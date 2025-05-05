using PT2.data.API;

namespace Tests.logic.helper;

 class FakeInventoryStateRepository : IInventoryStateRepository
{
    private readonly Dictionary<int, IInventoryState> _inventory = new Dictionary<int, IInventoryState>();

    public void AddInventoryState(IInventoryState state)
    {
        if (state == null)
            throw new ArgumentNullException(nameof(state));

        if (_inventory.ContainsKey(state.ItemId))
            throw new InvalidOperationException("Inventory state already exists.");

        _inventory[state.ItemId] = (IInventoryState)state;
    }

    IInventoryState IInventoryStateRepository.GetInventoryState(int itemId)
    {
        return GetInventoryState(itemId);
    }

    public IInventoryState GetInventoryState(int itemId) =>
        _inventory.TryGetValue(itemId, out var state) ? state : null;

    public void UpdateInventoryState(int itemId, int quantity)
    {
        if (_inventory.ContainsKey(itemId))
            _inventory[itemId].Quantity = quantity;
        else
            _inventory[itemId] = new MockInventoryState(itemId, quantity);
    }

    public void RemoveInventoryState(int itemId)
    {
        if (!_inventory.Remove(itemId))
            throw new InvalidOperationException("Inventory state not found.");
    }

    public List<IInventoryState> GetAllInventoryStates()
    {
        return null;
    }
}
