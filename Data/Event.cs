using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PT2.data.API;

namespace PT2.data
{
    [Table("Events")]
    internal class Event : IEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [MaxLength(50)]
        public string EventName { get; set; }

        public DateTime Timestamp { get; set; }

        public int UserId { get; set; }

        [MaxLength(255)]
        public string EventDescription { get; set; }

        public Event() { } // Required for EF Core

        public Event(int eventId, string eventName, DateTime timestamp, int userId, string eventDescription)
        {
            EventId = eventId;
            EventName = eventName;
            Timestamp = timestamp;
            UserId = userId;
            EventDescription = eventDescription;
        }

        public Event(IEvent evt)
        {
            EventId = evt.EventId;
            EventName = evt.EventName;
            Timestamp = evt.Timestamp;
            UserId = evt.UserId;
            EventDescription = evt.EventDescription;
        }

        public override string ToString()
        {
            return $"EventId: {EventId}, EventName: {EventName}, Timestamp: {Timestamp}, UserId: {UserId}, Description: {EventDescription}";
        }
    }
}