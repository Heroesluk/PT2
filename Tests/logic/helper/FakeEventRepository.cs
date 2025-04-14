using PT2.data.API.repository;
using PT2.data.model;
using PT2.DataModel;

namespace Tests.logic.helper;

class FakeEventRepository : IEventRepository
{
    private readonly List<IEvent> _events = new List<IEvent>();

    public void AddEvent(IEvent eventObj) => _events.Add(eventObj);
    public IEvent GetEvent(int eventId)
    {
        throw new NotImplementedException();
    }

    public List<IEvent> GetAllEvents() => new List<IEvent>(_events);

    public List<IEvent> GetEventsByUserId(int userId) =>
        _events.FindAll(e => e is PurchaseEvent pe && pe.UserId == userId);

    public List<IEvent> GetEventsByType(string type) =>
        _events.FindAll(e => e.GetType().Name == type);
}