using System.Collections.Generic;

namespace PT2.data.API
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
