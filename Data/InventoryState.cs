// Data/InventoryState.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PT2.data.API;

namespace PT2.data
{
    [Table("InventoryState")]
    internal class InventoryState: IInventoryState
    {
        public InventoryState(int itemId, int quantity)
        {
            ItemId = itemId;
            Quantity = quantity;
        }

        [Key]
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public virtual Item Item { get; set; }
    }
}