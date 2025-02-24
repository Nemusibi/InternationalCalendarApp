namespace CalendarAPI.Services
{
    public class HolidayService : IHolidayService
    {
        public async Task<List<Holiday>> GetHolidaysAsync(string country)
        {
           
            return new List<Holiday>
            {
                new Holiday { Date = "2025-01-01", Name = "New Year's Day" },
                new Holiday { Date = "2025-07-04", Name = "Independence Day" },
                new Holiday { Date = "2025-12-25", Name = "Christmas Day" }
            };
        }
    }

    public class Holiday
    {
        public string Date { get; set; }
        public string Name { get; set; }
    }
}
