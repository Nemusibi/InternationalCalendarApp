using CalendarAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CalendarAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
    }
}
