using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT2.data.model;

namespace PT2.logic.interfaces
{
    public interface ICatalogService
    {
        void AddItemToCatalog(int itemId, string name, string description, float price);
        List<Item> GetAllItems();
        Item GetItemById(int itemId);
        void UpdateItemDetails(int itemId, string name, string description, float price);
        void RemoveItemFromCatalog(int itemId);

    }
}
