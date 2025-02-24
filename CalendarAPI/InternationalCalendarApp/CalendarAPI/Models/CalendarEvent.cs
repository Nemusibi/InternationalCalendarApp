namespace CalendarAPI.Models
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Country { get; set; }
    }
}
