using System;

namespace PT2.DataModel;

public interface IEvent
{
    public int EventId { get; set; }
    public string EventName { get; set; }
    public DateTime Timestamp { get; set; }
    public int UserId { get; set; }
    public string EventDesciription { get; set; }
}