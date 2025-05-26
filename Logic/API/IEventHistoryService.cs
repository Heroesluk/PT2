using PT2.data.API;

namespace PT2.logic.API
{
    public interface IEventHistoryService
    {
        // TODO: replace Event abstract with concrete class.
        List<IEvent> GetAllPurchaseEvents();
        List<IEvent> GetUserPurchaseHistory(int userId);
        List<IEvent> GetPurchaseEventsByItemId(int itemId);
        
        void AddEvent(string eventName, int userId, string eventDescription);
    }
}
