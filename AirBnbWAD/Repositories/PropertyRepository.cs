using AirBnbWAD.Data;
using AirBnbWAD.Models;
using Microsoft.EntityFrameworkCore;

namespace AirBnbWAD.Repositories
{
    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {
        public PropertyRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Property>> GetPropertiesByLocationAsync(string location)
        {
            return await _context.Properties
                .Where(p => p.Location.Contains(location))
                .Include(p => p.Images)
                .ToListAsync();
        }

        public async Task<Property> GetPropertyWithDetailsAsync(int propertyId)
        {
            return await _context.Properties
                .Include(p => p.Owner)
                .Include(p => p.Images)
                .Include(p => p.Reviews)
                .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(p => p.PropertyID == propertyId);
        }

        public async Task<IEnumerable<Property>> GetPropertiesWithImagesAsync()
        {
            return await _context.Properties
                .Include(p => p.Images)
                .ToListAsync();
        }

        public async Task<IEnumerable<Property>> SearchPropertiesAsync(string searchTerm)
        {
            return await _context.Properties
                .Where(p => p.Title.Contains(searchTerm) ||
                            p.Description.Contains(searchTerm) ||
                            p.Location.Contains(searchTerm))
                .Include(p => p.Images)
                .ToListAsync();
        }
    }
}
