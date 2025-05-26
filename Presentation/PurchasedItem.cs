namespace Presentation;

// PurchasedItem.cs
internal class PurchasedItem
{
    public int ItemId { get; }
    public string Name { get; }
    public float Price { get; }
    public int Quantity { get; }
    public float TotalPrice => Price * Quantity;

    public PurchasedItem(int itemId, string name, float price, int quantity)
    {
        ItemId = itemId;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}