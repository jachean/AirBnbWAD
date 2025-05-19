using AirBnbWAD.Data;
using AirBnbWAD.Models;
using Microsoft.EntityFrameworkCore;

namespace AirBnbWAD.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review>> GetReviewsByPropertyAsync(int propertyId)
        {
            return await _context.Reviews
                .Where(r => r.PropertyID == propertyId)
                .Include(r => r.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsByUserAsync(int userId)
        {
            return await _context.Reviews
                .Where(r => r.UserID == userId)
                .Include(r => r.Property)
                .ToListAsync();
        }
    }
}