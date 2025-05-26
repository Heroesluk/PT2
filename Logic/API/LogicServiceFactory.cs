using Data.API;
using PT2.data.API;
using PT2.logic.API;

namespace PT2.logic
{
    public static class LogicServiceFactory
    {
        private static IDataService DataService => DataServiceFactory.Instance;

// LogicServiceFactory.cs

        public static ICatalogService CreateCatalogService()
        {
            var dataService = Data.API.DataServiceFactory.Instance;
            var inventoryService = new InventoryService(dataService);
            return new CatalogService(dataService, inventoryService);
        }


        public static IInventoryService CreateInventoryService()
        {
            return new InventoryService(DataService);
        }

        public static IPurchaseService CreatePurchaseService()
        {
            return new PurchaseService(DataService);
        }

        public static IShopService CreateShopService()
        {
            return new ShopService();
        }

        public static IUserService CreateUserService()
        {
            return new UserService(DataService);
        }
        
        public static IEventHistoryService CreateEventHistoryService()
        {
            return new EventHistoryService(DataService);
        }
    }
}