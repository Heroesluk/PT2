namespace PT2.DataModel;

public interface IPurchaseEvent
{
    
    int ItemId { get; set; }
    int Quantity { get; set; }
}