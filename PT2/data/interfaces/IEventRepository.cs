using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT2.data.model;

namespace PT2.data.interfaces
{
    public interface IEventRepository
    {
        void AddEvent(Event _event);

        Event GetEvent(int eventId);

        List<Event> GetAllEvents();

        List<Event> GetEventsByType(string name);

        List<Event> GetEventsByUserId(int userId);
    }


}
