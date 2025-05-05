namespace PT2.data;

internal class PurchaseEvent: Event
{
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}