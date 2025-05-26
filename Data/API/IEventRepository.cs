namespace PT2.data.API
{
    public interface IEventRepository
    {
        void AddEvent(IEvent _event);

        IEvent GetEvent(int eventId);

        List<IEvent> GetAllEvents();

        List<IEvent> GetEventsByType(string name);

        List<IEvent> GetEventsByUserId(int userId);
        
        public void removeEvent(int eventId);

        
    }
}