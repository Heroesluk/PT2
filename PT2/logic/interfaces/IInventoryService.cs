using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT2.data.model;

namespace PT2.logic.interfaces
{
    public interface IInventoryService
    {
        void AddStock(int itemId, int quantity);
        int GetItemStock(int itemId);
        void RemoveStock(int itemId, int quantity);

    }
}
