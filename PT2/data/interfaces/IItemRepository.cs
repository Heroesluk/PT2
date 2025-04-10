using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT2.data.model;

namespace PT2.data.interfaces
{
    internal interface IItemRepository
    {
        void AddItem(Item item);

        Item GetItem(int itemId);

        IEnumerable<Item> GetAllItems();
 
        void UpdateItem(Item item);
        void DeleteItem(int itemId);

        Item GetItemByName(string name);

        List<Item> GetItemsByPriceCutOff(float priceCutOff, string upDown);

    }
}
