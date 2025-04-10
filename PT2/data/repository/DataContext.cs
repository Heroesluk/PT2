using System.Collections.Generic;
using PT2.data.interfaces;
using PT2.data.model;

namespace PT2.data.repository;

public class DataContext : IDataContext
{
    public List<User> Users { get; }
    public Dictionary<int, Item> ItemsCatalog { get; }
    public List<InventoryState> Inventory { get; }
    public List<Event> Events { get; }
    
}