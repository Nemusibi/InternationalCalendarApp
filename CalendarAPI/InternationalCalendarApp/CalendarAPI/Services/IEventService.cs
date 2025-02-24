namespace CalendarAPI.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetEventsAsync(string country);
    }
}
