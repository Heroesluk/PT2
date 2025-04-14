using System;

namespace PT2.DataModel;

public interface IEvent
{
    int EventId { get; set; }
    string EventName { get; set; }
    DateTime Timestamp { get; set; }
    int UserId { get; set; }
    string EventDesciription { get; set; }
}