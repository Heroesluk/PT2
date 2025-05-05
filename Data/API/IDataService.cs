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
