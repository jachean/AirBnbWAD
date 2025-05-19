using AirBnbWAD.Models;
using AirBnbWAD.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirBnbWAD.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly IUserService _userService;

        public PropertiesController(IPropertyService propertyService, IUserService userService)
        {
            _propertyService = propertyService;
            _userService = userService;
        }

        // GET: Properties
        public async Task<IActionResult> Index(string searchString)
        {
            IEnumerable<Property> properties;

            if (!string.IsNullOrEmpty(searchString))
            {
                properties = await _propertyService.SearchPropertiesAsync(searchString);
                ViewData["CurrentFilter"] = searchString;
            }
            else
            {
                properties = await _propertyService.GetPropertiesWithImagesAsync();
            }

            return View(properties);
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var property = await _propertyService.GetPropertyWithDetailsAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        // GET: Properties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Location,Price,OwnerID")] Property property)
        {
            if (ModelState.IsValid)
            {
                await _propertyService.CreatePropertyAsync(property);
                return RedirectToAction(nameof(Index));
            }
            return View(property);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return View(property);
        }

        // POST: Properties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyID,Title,Description,Location,Price,OwnerID")] Property property)
        {
            if (id != property.PropertyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _propertyService.UpdatePropertyAsync(property);
                return RedirectToAction(nameof(Index));
            }
            return View(property);
        }

        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _propertyService.DeletePropertyAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
