using EventHub.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EventHub.Infrastructure
{
    public class EventHubDBContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Attendee> Attendee { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<EventCategory> EventCategory { get; set; }
        public DbSet<CheckIn> CheckIn { get; set; }
        public EventHubDBContext(DbContextOptions<EventHubDBContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCategory>()
                .HasKey(ec => new { ec.ID_Event, ec.ID_Category });

            modelBuilder.Entity<EventCategory>()
                .HasOne(ec => ec.Event);

            modelBuilder.Entity<EventCategory>()
                .HasOne(ec => ec.Category)
                .WithMany()
                .HasForeignKey(ec => ec.ID_Category);
        }


    }
}
