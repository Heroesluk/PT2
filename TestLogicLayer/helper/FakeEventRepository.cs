using PT2.data.API;

namespace Tests.logic.helper;

class FakeEventRepository : IEventRepository
{
    private readonly List<IEvent> _events = new List<IEvent>();

    public void AddEvent(IEvent eventObj) => _events.Add(eventObj);
    public IEvent GetEvent(int eventId)
    {
        if (eventId < 0)
            throw new ArgumentOutOfRangeException(nameof(eventId), "Identifier cannot be negative.");

        return _events.FirstOrDefault(e => e.EventId == eventId);
    }

    public List<IEvent> GetAllEvents() => new List<IEvent>(_events);

    public List<IEvent> GetEventsByUserId(int userId) =>
        _events.FindAll(e => e.UserId == userId);

    public List<IEvent> GetEventsByType(string type) =>
        _events.FindAll(e => e.GetType().Name == type);
}