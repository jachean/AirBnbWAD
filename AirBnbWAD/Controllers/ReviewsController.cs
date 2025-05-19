using AirBnbWAD.Models;
using AirBnbWAD.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirBnbWAD.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IPropertyService _propertyService;
        private readonly IUserService _userService;

        public ReviewsController(IReviewService reviewService, IPropertyService propertyService, IUserService userService)
        {
            _reviewService = reviewService;
            _propertyService = propertyService;
            _userService = userService;
        }

        // GET: Reviews
        public async Task<IActionResult> Index(int? propertyId)
        {
            if (propertyId.HasValue)
            {
                var propertyReviews = await _reviewService.GetReviewsByPropertyAsync(propertyId.Value);
                ViewData["PropertyID"] = propertyId.Value;
                var property = await _propertyService.GetPropertyByIdAsync(propertyId.Value);
                if (property != null)
                {
                    ViewData["PropertyTitle"] = property.Title;
                }
                return View(propertyReviews);
            }
            else
            {
                var reviews = await _reviewService.GetAllReviewsAsync();
                return View(reviews);
            }
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public async Task<IActionResult> Create(int? propertyId)
        {
            if (propertyId.HasValue)
            {
                var property = await _propertyService.GetPropertyByIdAsync(propertyId.Value);
                if (property != null)
                {
                    ViewData["PropertyID"] = propertyId.Value;
                    ViewData["PropertyTitle"] = property.Title;
                }
            }

            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyID,UserID,Rating,Comment")] Review review)
        {
            if (ModelState.IsValid)
            {
                review.Date = DateTime.Now;
                await _reviewService.CreateReviewAsync(review);
                return RedirectToAction(nameof(Index), new { propertyId = review.PropertyID });
            }
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewID,PropertyID,UserID,Rating,Comment,Date")] Review review)
        {
            if (id != review.ReviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _reviewService.UpdateReviewAsync(review);
                return RedirectToAction(nameof(Index), new { propertyId = review.PropertyID });
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            int propertyId = review.PropertyID;

            await _reviewService.DeleteReviewAsync(id);
            return RedirectToAction(nameof(Index), new { propertyId = propertyId });
        }
    }
}
