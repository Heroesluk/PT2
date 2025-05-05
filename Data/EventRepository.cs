using PT2.data.API;

namespace PT2.data;

internal class EventRepository : IEventRepository
{ 
    private readonly IDataContext DataContext;
    
    public EventRepository(IDataContext dataContext)
    {
        DataContext = dataContext;
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
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Name cannot be null or empty.");
        }

        return DataContext.Events.Where(e => e.GetType().Name.Equals(name)).ToList();
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
