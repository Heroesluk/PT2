using PT2.data.API;

namespace Logic;

public class InventoryStateDto: IInventoryState
{
    public InventoryStateDto(int itemId, int quantity)
    {
        ItemId = itemId;
        Quantity = quantity;
    }

    public int ItemId { get; set; }
    public int Quantity { get; set; }
}