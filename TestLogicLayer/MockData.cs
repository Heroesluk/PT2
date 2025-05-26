using PT2.data.API;

namespace TestLogicLayer;


internal class MockItem : IItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }

    public MockItem(int id, string name, string description, float price)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
    }
    
}

internal class MockEvent : IEvent
{
    public int EventId { get; set; }
    public string EventName { get; set; }
    public DateTime Timestamp { get; set; }
    public int UserId { get; set; }
    public string EventDescription { get; set; }

    public MockEvent(int eventId, string eventName, DateTime timestamp, int userId, string description)
    {
        EventId = eventId;
        EventName = eventName;
        Timestamp = timestamp;
        UserId = userId;
        EventDescription = description;
    }
}

internal class MockInventoryState : IInventoryState
{
    public int ItemId { get; set; }
    public int Quantity { get; set; }

    public MockInventoryState(int itemId, int quantity)
    {
        ItemId = itemId;
        Quantity = quantity;
    }
}





internal class MockPurchaseEvent : IEvent, IPurchaseEvent
{
    public int ItemId { get; set; }
    public int Quantity { get; set; }

    public MockPurchaseEvent(int itemId, int quantity)
    {
        ItemId = itemId;
        Quantity = quantity;
    }

    public int EventId { get; set; }
    public string EventName { get; set; }
    public DateTime Timestamp { get; set; }
    public int UserId { get; set; }
    public string EventDescription { get; set; }
}

internal class MockUser : IUser
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public MockUser(int id, string username, string password, string email)
    {
        Id = id;
        Username = username;
        Password = password;
        Email = email;
    }
}