namespace CalendarClient.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Country { get; set; } = string.Empty;
    }
}