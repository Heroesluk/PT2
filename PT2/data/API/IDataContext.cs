using System.Collections.Generic;
using PT2.data.model;
using PT2.DataModel;

namespace PT2.data.interfaces
{
    // this will hold all of our data in context of application
    public interface IDataContext
    {
        List<IUser> Users { get; }

        Dictionary<int, IItem> ItemsCatalog { get; }

        List<IInventoryState> Inventory { get; }

        List<IEvent> Events { get; }
    }

}
