using AirBnbWAD.Models;
using AirBnbWAD.Repositories;

namespace AirBnbWAD.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUserWithPropertiesAsync(int id)
        {
            return await _userRepository.GetUserWithPropertiesAsync(id);
        }

        public async Task<User> GetUserWithBookingsAsync(int id)
        {
            return await _userRepository.GetUserWithBookingsAsync(id);
        }

        public async Task<User> GetUserWithReviewsAsync(int id)
        {
            return await _userRepository.GetUserWithReviewsAsync(id);
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                _userRepository.Remove(user);
                await _userRepository.SaveChangesAsync();
            }
        }
    }
}