using System.Collections.Generic;
using PT2.data.model;

namespace PT2.logic.interfaces
{
    public interface IShopService
    {
        // User Management
        void RegisterUser(string username, string password, string email);
        void RemoveUser(string username);
        bool IsUserRegistered(string username);

        // Catalog Management
        void AddItemToCatalog(int itemId, string name, string description, decimal price);
        List<Item> GetAllItems();
        Item GetItemById(int itemId);
        void UpdateItemDetails(int itemId, string name, string description, decimal price);
        void RemoveItemFromCatalog(int itemId);

        // Purchase Management
        void AddStock(int itemId, int quantity);
        int GetItemStock(int itemId);
        void RemoveStock(int itemId, int quantity);

        // Purchase
        void SellItem(int userId, int itemId, int quantity);
        decimal CalculateTotalPrice(int itemId, int quantity);

        // Event historyy
        // TODO: replace Event abstract with concrete class.
        List<Event> GetAllPurchaseEvents();
        List<Event> GetUserPurchaseHistory(int userId);
        List<Event> GetPurchaseEventsByItemId(int itemId);
    }
}