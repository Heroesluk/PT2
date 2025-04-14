using System.Collections.Generic;
using PT2.DataModel;

namespace PT2.data.API.repository
{
    public interface IEventRepository
    {
        void AddEvent(IEvent _event);

        IEvent GetEvent(int eventId);

        List<IEvent> GetAllEvents();

        List<IEvent> GetEventsByType(string name);

        List<IEvent> GetEventsByUserId(int userId);
    }
}