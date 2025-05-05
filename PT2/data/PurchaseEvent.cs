namespace PT2.data;

public class PurchaseEvent: Event
{
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}