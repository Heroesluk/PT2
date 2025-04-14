using PT2.data.API.repository;
using PT2.data.model;
using PT2.DataModel;

namespace Tests.logic.helper;

 class FakeInventoryStateRepository : IInventoryStateRepository
{
    private readonly Dictionary<int, InventoryState> _inventory = new Dictionary<int, InventoryState>();

    public void AddInventoryState(IInventoryState state)
    {
        throw new NotImplementedException();
    }

    IInventoryState IInventoryStateRepository.GetInventoryState(int itemId)
    {
        return GetInventoryState(itemId);
    }

    public InventoryState GetInventoryState(int itemId) =>
        _inventory.TryGetValue(itemId, out var state) ? state : null;

    public void UpdateInventoryState(int itemId, int quantity)
    {
        if (_inventory.ContainsKey(itemId))
            _inventory[itemId].Quantity = quantity;
        else
            _inventory[itemId] = new InventoryState { ItemId = itemId, Quantity = quantity };
    }

    public void RemoveInventoryState(int itemId)
    {
        throw new NotImplementedException();
    }

    public List<IInventoryState> GetAllInventoryStates()
    {
        throw new NotImplementedException();
    }
}
