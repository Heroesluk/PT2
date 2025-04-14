using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT2.data.model;
using PT2.DataModel;

namespace PT2.logic.interfaces
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
