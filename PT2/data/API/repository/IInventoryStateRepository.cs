using System.Collections.Generic;
using PT2.DataModel;

namespace PT2.data.API.repository
{
    public interface IInventoryStateRepository
    {
        void AddInventoryState(IInventoryState state);
  
        IInventoryState GetInventoryState(int itemId);

        void UpdateInventoryState(int itemId, int newQuantity);

        void RemoveInventoryState(int itemId);

        List<IInventoryState> GetAllInventoryStates();
    }

}
