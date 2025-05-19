using AirBnbWAD.Models;
using Microsoft.EntityFrameworkCore;

namespace AirBnbWAD.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    public class DataContext(DbContextOptions<DataContext> options)
        : IdentityDbContext<IdentityUser>(options)
    {
        public DbSet<User> User { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Image> Images { get; set; }
    }
    
}
