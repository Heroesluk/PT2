using PT2.data.API;

namespace PT2.logic.API
{
    public interface ICatalogService
    {
        void AddItemToCatalog(int itemId, string name, string description, float price);
        List<IItem> GetAllItems();
        IItem GetItemById(int itemId);
        void UpdateItemDetails(int itemId, string name, string description, float price);
        void RemoveItemFromCatalog(int itemId);

    }
}
