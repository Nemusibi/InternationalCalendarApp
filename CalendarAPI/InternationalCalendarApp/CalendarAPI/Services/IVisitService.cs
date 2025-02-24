using CalendarAPI.Models;

namespace CalendarAPI.Services
{
    public interface IVisitService
    {
        Task<List<Visit>> GetVisitsAsync();
        Task<Visit> AddVisitAsync(Visit visit);
        Task<bool> DeleteVisitAsync(int id);
    }
}