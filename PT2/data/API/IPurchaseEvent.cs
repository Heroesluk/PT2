namespace PT2.data.API;

public interface IPurchaseEvent
{
    
    int ItemId { get; set; }
    int Quantity { get; set; }
}