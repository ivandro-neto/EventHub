using EventHub.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Infrastructure
{
    public class EventHubDBContext(DbContextOptions<EventHubDBContext> options) : DbContext(options)
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<EventCategory> EventsCategory { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
    }
}
