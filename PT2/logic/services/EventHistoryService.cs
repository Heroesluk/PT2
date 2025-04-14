using System.Collections.Generic;
using PT2.data.API.repository;
using PT2.data.model;
using PT2.DataModel;
using PT2.logic.interfaces;

namespace PT2.logic.services
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
