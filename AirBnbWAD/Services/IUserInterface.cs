using AirBnbWAD.Models;

namespace AirBnbWAD.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserWithPropertiesAsync(int id);
        Task<User> GetUserWithBookingsAsync(int id);
        Task<User> GetUserWithReviewsAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}