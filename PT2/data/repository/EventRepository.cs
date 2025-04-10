using System.Collections.Generic;
using PT2.data.interfaces;
using PT2.data.model;

namespace PT2.data.repository;

public class EventRepository : IEventRepository
{ 
    private readonly IDataContext DataContext;
    
    public EventRepository(IDataContext dataContext)
    {
        this.DataContext = dataContext;
    }

    public void AddEvent(Event _event)
    {
        throw new System.NotImplementedException();
    }

    public Event GetEvent(int eventId)
    {
        throw new System.NotImplementedException();
    }

    public List<Event> GetAllEvents()
    {
        throw new System.NotImplementedException();
    }

    public List<Event> GetEventsByType(string name)
    {
        throw new System.NotImplementedException();
    }

    public List<Event> GetEventsByUserId(int userId)
    {
        throw new System.NotImplementedException();
    }
}