using PT2.data.API;

namespace PT2.data
{
    internal class DataService : IDataService
    {
        public IUserRepository userRepo { get; }
        public IItemRepository itemRepo { get; }
        public IInventoryStateRepository inventoryStateRepo { get; }
        public IEventRepository eventRepo { get; }

        private IDataContext dataContext { get; set; }

        internal DataService(IDataContext dataContext)
        {
            this.dataContext = dataContext;


            userRepo = new UserRepository(dataContext);
            itemRepo = new ItemRepository(dataContext);
            inventoryStateRepo = new InventoryStateRepository(dataContext);
            eventRepo = new EventRepository(dataContext);
        }

        public DataService()
        {
            dataContext = new DataContext();
            
            userRepo = new UserRepository(dataContext);
            itemRepo = new ItemRepository(dataContext);
            inventoryStateRepo = new InventoryStateRepository(dataContext);
            eventRepo = new EventRepository(dataContext);
            
        }
    }
}