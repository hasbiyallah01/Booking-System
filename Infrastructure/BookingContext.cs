using Booking_System.Core.Domain.Entity;
using Booking_System.Core.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking_System.Infrastructure
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UsageAnalytics> UsageAnalytics { get; set; }
        public DbSet<Zone> Zones { get; set; }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }


    }
}
