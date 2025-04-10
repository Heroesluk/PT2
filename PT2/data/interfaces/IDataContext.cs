using System.Collections.Generic;
using PT2.data.model;

namespace PT2.data.interfaces
{
    // this will hold all of our data in context of application
    public interface IDataContext
    {
        List<User> Users { get; }

        Dictionary<int, Item> ItemsCatalog { get; }

        List<InventoryState> Inventory { get; }

        List<Event> Events { get; }
    }

}
