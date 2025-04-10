using System.Collections.Generic;
using PT2.data.interfaces;
using PT2.data.model;

namespace PT2.data.repository;

public class ItemRepository: IItemRepository
{
    
    private readonly IDataContext DataContext;
    
    public ItemRepository(IDataContext dataContext)
    {
        DataContext = dataContext;
    }
    
    public void AddItem(Item item)
    {
        throw new System.NotImplementedException();
    }

    public Item GetItem(int itemId)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<Item> GetAllItems()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateItem(Item item)
    {
        throw new System.NotImplementedException();
    }

    public void DeleteItem(int itemId)
    {
        throw new System.NotImplementedException();
    }

    public Item GetItemByName(string name)
    {
        throw new System.NotImplementedException();
    }

    public List<Item> GetItemsByPriceCutOff(float priceCutOff, string upDown)
    {
        throw new System.NotImplementedException();
    }
}