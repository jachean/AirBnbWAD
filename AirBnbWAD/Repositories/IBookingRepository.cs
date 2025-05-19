using AirBnbWAD.Models;

namespace AirBnbWAD.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsByUserAsync(int userId);
        Task<IEnumerable<Booking>> GetBookingsByPropertyAsync(int propertyId);
        Task<Booking> GetBookingWithDetailsAsync(int bookingId);
    }
}