namespace CalendarAPI.Services
{
    public interface IHolidayService
    {
        Task<List<Holiday>> GetHolidaysAsync(string country);
    }
}
