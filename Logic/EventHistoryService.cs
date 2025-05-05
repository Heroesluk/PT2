using PT2.data.API;
using PT2.Logic;
using PT2.logic.API;

namespace PT2.logic
{
    public class EventHistoryService : IEventHistoryService
    {
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
    }
}
