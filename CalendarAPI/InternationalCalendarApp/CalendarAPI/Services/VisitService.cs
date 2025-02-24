using CalendarAPI.Models;

namespace CalendarAPI.Services
{
    public class VisitService : IVisitService
    {
        private static List<Visit> _visits = new();
        private static int _nextId = 1;

        public Task<List<Visit>> GetVisitsAsync()
        {
            return Task.FromResult(_visits.OrderByDescending(v => v.Date).ToList());
        }

        public Task<Visit> AddVisitAsync(Visit visit)
        {
            
            if (string.IsNullOrWhiteSpace(visit.Country))
            {
                throw new ArgumentException("Country cannot be empty");
            }

            
            var newVisit = new Visit
            {
                Id = _nextId++,
                Date = visit.Date.Date, 
                Country = visit.Country.Trim()
            };

            _visits.Add(newVisit);
            return Task.FromResult(newVisit);
        }

        public Task<bool> DeleteVisitAsync(int id)
        {
            var visit = _visits.FirstOrDefault(v => v.Id == id);
            if (visit != null)
            {
                _visits.Remove(visit);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}