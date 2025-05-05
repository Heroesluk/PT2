using PT2.data.API;

namespace Tests.logic.helper
{
    public class FakeDataService : IDataService
    {
        public IUserRepository userRepo { get; }
        public IItemRepository itemRepo { get; }
        public IInventoryStateRepository inventoryStateRepo { get; }
        public IEventRepository eventRepo { get; }

        public FakeDataService() {
            userRepo = new FakeUserRepository();
            itemRepo = new FakeItemRepository();
            inventoryStateRepo = new FakeInventoryStateRepository();
            eventRepo = new FakeEventRepository();
        }
    }
}
