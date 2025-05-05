using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PT2.data.API;

namespace PT2.data
{
    public class DataService : IDataService
    {
        public IUserRepository userRepo { get; }
        public IItemRepository itemRepo { get; }
        public IInventoryStateRepository inventoryStateRepo { get; }
        public IEventRepository eventRepo { get; }

        public IDataContext dataContext { get; }

        public DataService(IDataContext dataContext = null) {
            if (dataContext == null)
            {
                dataContext = new DataContext();
            }
            else
            {
                this.dataContext = dataContext;
            }

            userRepo = new UserRepository(dataContext);
            itemRepo = new ItemRepository(dataContext);
            inventoryStateRepo = new InventoryStateRepository(dataContext);
            eventRepo = new EventRepository(dataContext);
        }
    }
}
