using AirBnbWAD.Data;
using AirBnbWAD.Models;
using Microsoft.EntityFrameworkCore;

namespace AirBnbWAD.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserAsync(int userId)
        {
            return await _context.Bookings
                .Where(b => b.UserID == userId)
                .Include(b => b.Property)
                .ThenInclude(p => p.Images)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByPropertyAsync(int propertyId)
        {
            return await _context.Bookings
                .Where(b => b.PropertyID == propertyId)
                .Include(b => b.User)
                .ToListAsync();
        }

        public async Task<Booking> GetBookingWithDetailsAsync(int bookingId)
        {
            return await _context.Bookings
                .Include(b => b.Property)
                .ThenInclude(p => p.Images)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.BookingID == bookingId);
        }
    }
}
