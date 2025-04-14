namespace PT2.data.API.model;

public interface IPurchaseEvent
{
    
    int ItemId { get; set; }
    int Quantity { get; set; }
}