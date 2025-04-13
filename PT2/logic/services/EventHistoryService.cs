using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT2.data.interfaces;
using PT2.data.model;
using PT2.data.repository;
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

        public List<Event> GetAllPurchaseEvents()
        {
            return _eventRepository.GetAllEvents();
        }

        public List<Event> GetUserPurchaseHistory(int userId)
        {
            return _eventRepository.GetEventsByUserId(userId);
        }

        public List<Event> GetPurchaseEventsByItemId(int itemId)
        {
            return _eventRepository.GetEventsByType("Purchase")
                .FindAll(e => e is PurchaseEvent pe && pe.ItemId == itemId);
        }
    }
}
