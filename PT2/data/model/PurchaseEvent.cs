namespace PT2.data.model;

public class PurchaseEvent: Event
{
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}