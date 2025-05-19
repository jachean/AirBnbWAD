using AirBnbWAD.Models;
using AirBnbWAD.Repositories;

namespace AirBnbWAD.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _reviewRepository.GetAllAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _reviewRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Review>> GetReviewsByPropertyAsync(int propertyId)
        {
            return await _reviewRepository.GetReviewsByPropertyAsync(propertyId);
        }

        public async Task<IEnumerable<Review>> GetReviewsByUserAsync(int userId)
        {
            return await _reviewRepository.GetReviewsByUserAsync(userId);
        }

        public async Task CreateReviewAsync(Review review)
        {
            await _reviewRepository.AddAsync(review);
            await _reviewRepository.SaveChangesAsync();
        }

        public async Task UpdateReviewAsync(Review review)
        {
            _reviewRepository.Update(review);
            await _reviewRepository.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review != null)
            {
                _reviewRepository.Remove(review);
                await _reviewRepository.SaveChangesAsync();
            }
        }
    }
}