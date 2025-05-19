using AirBnbWAD.Models;

namespace AirBnbWAD.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserWithPropertiesAsync(int userId);
        Task<User> GetUserWithBookingsAsync(int userId);
        Task<User> GetUserWithReviewsAsync(int userId);
    }
}