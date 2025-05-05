using System.Collections.Generic;
using PT2.data.API;

namespace PT2.data;

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