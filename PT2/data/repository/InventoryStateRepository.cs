using System;
using System.Collections.Generic;
using System.Linq;
using PT2.data.API.repository;
using PT2.data.interfaces;
using PT2.data.model;
using PT2.DataModel;

namespace PT2.data.repository
{
    public class InventoryStateRepository : IInventoryStateRepository
    {
        private readonly IDataContext _dataContext;

        public InventoryStateRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddInventoryState(IInventoryState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            if (_dataContext.Inventory.Any(i => i.ItemId == state.ItemId))
                throw new InvalidOperationException("Inventory state for this item already exists.");

            _dataContext.Inventory.Add(state);
        }

        public IInventoryState GetInventoryState(int itemId)
        {
            return _dataContext.Inventory.FirstOrDefault(i => i.ItemId == itemId);
        }

        public void UpdateInventoryState(int itemId, int newQuantity)
        {
            var state = GetInventoryState(itemId);
            if (state == null)
                throw new InvalidOperationException("Inventory state not found.");

            state.Quantity = newQuantity;
        }

        public void RemoveInventoryState(int itemId)
        {
            var state = GetInventoryState(itemId);
            if (state == null)
                throw new InvalidOperationException("Inventory state not found.");

            _dataContext.Inventory.Remove(state);
        }

        public List<IInventoryState> GetAllInventoryStates()
        {
            return _dataContext.Inventory.ToList();
        }
    }
}