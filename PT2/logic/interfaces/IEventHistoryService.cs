using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT2.data.model;

namespace PT2.logic.interfaces
{
    public interface IEventHistoryService
    {
        // TODO: replace Event abstract with concrete class.
        List<Event> GetAllPurchaseEvents();
        List<Event> GetUserPurchaseHistory(int userId);
        List<Event> GetPurchaseEventsByItemId(int itemId);
    }
}
