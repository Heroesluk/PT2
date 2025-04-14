using System.Collections.Generic;
using PT2.DataModel;

namespace PT2.logic.interfaces
{
    public interface IEventHistoryService
    {
        // TODO: replace Event abstract with concrete class.
        List<IEvent> GetAllPurchaseEvents();
        List<IEvent> GetUserPurchaseHistory(int userId);
        List<IEvent> GetPurchaseEventsByItemId(int itemId);
    }
}
