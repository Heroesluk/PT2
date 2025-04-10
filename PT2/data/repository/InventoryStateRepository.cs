using System.Collections.Generic;
using PT2.data.interfaces;
using PT2.data.model;

namespace PT2.data.repository;

public class InventoryStateRepository: IInventoryStateRepository
{
    
    private readonly IDataContext DataContext;
    
    public InventoryStateRepository(IDataContext dataContext)
    {
        DataContext = dataContext;
    }
    
    public void AddInventoryState(InventoryState state)
    {
        throw new System.NotImplementedException();
    }

    public InventoryState GetInventoryState(int itemId)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateInventoryState(int itemId, int newQuantity)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveInventoryState(int itemId)
    {
        throw new System.NotImplementedException();
    }

    public List<InventoryState> GetAllInventoryStates()
    {
        throw new System.NotImplementedException();
    }
}