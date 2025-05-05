using System.Collections.Generic;
using PT2.data;
using PT2.data.API;
using PT2.logic.API;

namespace PT2.logic
{
    public class EventHistoryService : IEventHistoryService
    {
        private IEventRepository _eventRepository;

        public EventHistoryService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public List<IEvent> GetAllPurchaseEvents()
        {
            return _eventRepository.GetAllEvents();
        }

        public List<IEvent> GetUserPurchaseHistory(int userId)
        {
            return _eventRepository.GetEventsByUserId(userId);
        }

        public List<IEvent> GetPurchaseEventsByItemId(int itemId)
        {
            return _eventRepository.GetEventsByType("Purchase")
                .FindAll(e => e is PurchaseEvent pe && pe.ItemId == itemId);
        }
    }
}
