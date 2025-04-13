using System.Collections.Generic;
using PT2.data.interfaces;
using PT2.data.model;

namespace PT2.data.repository;

public class DataContext : IDataContext
{
    public List<User> Users { get; set; }
    public Dictionary<int, Item> ItemsCatalog { get; set; }
    public List<InventoryState> Inventory { get; set; }
    public List<Event> Events { get; set; }

    public DataContext()
    {
        Users = new List<User>();
        ItemsCatalog = new Dictionary<int, Item>();
        Inventory = new List<InventoryState>();
        Events = new List<Event>();

    }

}