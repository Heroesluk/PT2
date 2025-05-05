using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2.data.API
{
    public interface IDataService
    {
        IUserRepository userRepo { get; }
        IItemRepository itemRepo { get; }
        IInventoryStateRepository inventoryStateRepo { get; }
        IEventRepository eventRepo { get; }

    }
}
