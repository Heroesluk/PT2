using PT2.data.API;

namespace PT2.data
{


    internal abstract class Event: IEvent
    {

        public int EventId { get; set; }

        public string EventName { get; set; }

        public DateTime Timestamp { get; set; }

        // of the user that invoked the vent
        public int UserId { get; set; }

        public string EventDesciription { get; set; }

    }


}
