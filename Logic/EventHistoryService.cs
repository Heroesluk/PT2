using PT2.data.API;
using PT2.Logic;
using PT2.logic.API;

namespace PT2.logic
{
    public class EventHistoryService : IEventHistoryService
    {
        
        internal class EventDto : IEvent
        {
            public int EventId { get; set; }
            public string EventName { get; set; }
            public DateTime Timestamp { get; set; }
            public int UserId { get; set; }
            public string EventDesciription { get; set; }
        }
        
        
        //private IEventRepository _eventRepository;
        private IDataService _dataService;

        public EventHistoryService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public List<IEvent> GetAllPurchaseEvents()
        {
            return _dataService.eventRepo.GetAllEvents();
        }

        public List<IEvent> GetUserPurchaseHistory(int userId)
        {
            return _dataService.eventRepo.GetEventsByUserId(userId);
        }

        public List<IEvent> GetPurchaseEventsByItemId(int itemId)
        {
            return _dataService.eventRepo.GetEventsByType("Purchase")
                .FindAll(e => e is PurchaseEventDto pe && pe.ItemId == itemId);
        }
        
        public void AddEvent(String eventName, int userId, string eventDescription)
        {
            if (string.IsNullOrWhiteSpace(eventName))
            {
                throw new ArgumentException("Event name cannot be null or empty", nameof(eventName));
            }

            if (string.IsNullOrWhiteSpace(eventDescription))
            {
                throw new ArgumentException("Event description cannot be null or empty", nameof(eventDescription));
            }

            var eventDto = new EventDto
            {
                EventName = eventName,
                Timestamp = DateTime.UtcNow,
                UserId = userId,
                EventDesciription = eventDescription
            };
            Console.WriteLine($"Event Logged: Name={eventDto.EventName}, UserId={eventDto.UserId}, Description={eventDto.EventDesciription}, Timestamp={eventDto.Timestamp}");

            _dataService.eventRepo.AddEvent(eventDto);
        }

        
    }
}