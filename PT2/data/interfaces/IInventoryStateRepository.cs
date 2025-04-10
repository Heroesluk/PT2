using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT2.data.model;

namespace PT2.data.interfaces
{
    public interface IInventoryStateRepository
    {
        void AddInventoryState(InventoryState state);
  
        InventoryState GetInventoryState(int itemId);

        void UpdateInventoryState(int itemId, int newQuantity);

        void RemoveInventoryState(int itemId);

        List<InventoryState> GetAllInventoryStates();
    }

}
