using System;
using System.Collections.Generic;
using System.Linq;
using PT2.data.API.repository;
using PT2.data.interfaces;
using PT2.DataModel;

namespace PT2.data.repository;

public class EventRepository : IEventRepository
{ 
    private readonly IDataContext DataContext;
    
    public EventRepository(IDataContext dataContext)
    {
        this.DataContext = dataContext;
    }

    public void AddEvent(IEvent _event)
    {
        if (_event == null)
            throw new ArgumentNullException(nameof(_event));

        DataContext.Events.Add(_event);
    }

    public IEvent GetEvent(int eventId)
    {
        //TO DO: Verify
        if (eventId < 0)
        {
            throw new ArgumentOutOfRangeException("Identifier cannot be negative.");
        }

        return DataContext.Events.First(e => e.EventId.Equals(eventId));
    }

    public List<IEvent> GetAllEvents()
    {
        return DataContext.Events.ToList();
    }

    //TO DO: implement
    public List<IEvent> GetEventsByType(string name)
    {
        throw new NotImplementedException();
    }

    public List<IEvent> GetEventsByUserId(int userId)
    {
        //TO DO: Verify
        if (userId < 0)
        {
            throw new ArgumentOutOfRangeException("Identifier cannot be negative.");
        }

        //TO DO: Check & Verify
        return DataContext.Events.Where(e => {
            //protection when Event don't contain userId (is not a PurchaseEvent for example)
            try
            {
                e.UserId.Equals(userId);
            }
            catch
            {
                return false;
            }

            return e.UserId.Equals(userId);
        }
        ).ToList();
    }
}
