using AirBnbWAD.Data;
using AirBnbWAD.Models;
using Microsoft.EntityFrameworkCore;

namespace AirBnbWAD.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task<User> GetUserWithPropertiesAsync(int userId)
        {
            return await _context.User
                .Include(u => u.Properties)
                .FirstOrDefaultAsync(u => u.UserID == userId);
        }

        public async Task<User> GetUserWithBookingsAsync(int userId)
        {
            return await _context.User
                .Include(u => u.Bookings)
                .ThenInclude(b => b.Property)
                .FirstOrDefaultAsync(u => u.UserID == userId);
        }

        public async Task<User> GetUserWithReviewsAsync(int userId)
        {
            return await _context.User
                .Include(u => u.Reviews)
                .ThenInclude(r => r.Property)
                .FirstOrDefaultAsync(u => u.UserID == userId);
        }
    }
}