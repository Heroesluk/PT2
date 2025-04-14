using System.Collections.Generic;
using PT2.data.interfaces;
using PT2.data.model;
using PT2.DataModel;

namespace PT2.data.repository;

public class DataContext : IDataContext
{
    public List<IUser> Users { get; set; }
    public Dictionary<int, IItem> ItemsCatalog { get; set; }
    public List<IInventoryState> Inventory { get; set; }
    public List<IEvent> Events { get; set; }

    public DataContext()
    {
        Users = new List<IUser>();
        ItemsCatalog = new Dictionary<int, IItem>();
        Inventory = new List<IInventoryState>();
        Events = new List<IEvent>();

    }

}