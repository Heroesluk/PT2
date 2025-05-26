using Data;
using PT2.data;
using PT2.data.API;
using Microsoft.EntityFrameworkCore;

namespace PT2.data
{
    public class EventDbRepository : IEventRepository
    {
        private readonly ShopDbContext _dbContext;

        internal EventDbRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddEvent(IEvent _event)
        {
            if (_event == null)
                throw new ArgumentNullException(nameof(_event));
            var vent = new Event(
                _event.EventId,
                _event.EventName,
                _event.Timestamp,
                _event.UserId,
                _event.EventDesciription);
            _dbContext.Events.Add(vent);
            _dbContext.SaveChanges();
        }

        public IEvent GetEvent(int eventId)
        {
            if (eventId < 0)
                throw new ArgumentOutOfRangeException(nameof(eventId), "Identifier cannot be negative.");

            var _event = _dbContext.Events
                .AsNoTracking()
                .FirstOrDefault(e => e.EventId == eventId);

            if (_event == null)
                throw new InvalidOperationException($"Event with ID {eventId} not found.");

            return _event;
        }

        public List<IEvent> GetAllEvents()
        {
            return _dbContext.Events
                .AsNoTracking()
                .ToList<IEvent>();
        }

        public List<IEvent> GetEventsByType(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");

            return _dbContext.Events
                .AsNoTracking()
                .Where(e => e.GetType().Name == name)
                .ToList<IEvent>();
        }

        public List<IEvent> GetEventsByUserId(int userId)
        {
            if (userId < 0)
                throw new ArgumentOutOfRangeException(nameof(userId), "User ID cannot be negative.");

            return _dbContext.Events
                .AsNoTracking()
                .Where(e => e.UserId == userId)
                .ToList<IEvent>();
        }
    }
}