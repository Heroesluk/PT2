using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT2.data.model;
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
