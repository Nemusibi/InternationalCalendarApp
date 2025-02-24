namespace CalendarAPI.Services
{
    public class EventService : IEventService
    {
        public async Task<List<Event>> GetEventsAsync(string country)
        {
            
            return new List<Event>
            {
                new Event { Date = "2025-06-15", Name = "Summer Festival" },
                new Event { Date = "2025-09-20", Name = "Music Concert" },
                new Event { Date = "2025-11-05", Name = "Tech Conference" }
            };
        }
    }

    public class Event
    {
        public string Date { get; set; }
        public string Name { get; set; }
    }
}
