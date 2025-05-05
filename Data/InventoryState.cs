using PT2.data.API;

namespace PT2.data
{
    // this will be used to represent number of specific item in the inventory
    internal class InventoryState : IInventoryState
    {
        public int ItemId { get; set; }

        public int Quantity { get; set; }

    }
}