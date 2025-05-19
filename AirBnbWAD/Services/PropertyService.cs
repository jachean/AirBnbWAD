using AirBnbWAD.Models;
using AirBnbWAD.Repositories;

namespace AirBnbWAD.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<IEnumerable<Property>> GetAllPropertiesAsync()
        {
            return await _propertyRepository.GetAllAsync();
        }

        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await _propertyRepository.GetByIdAsync(id);
        }

        public async Task<Property> GetPropertyWithDetailsAsync(int id)
        {
            return await _propertyRepository.GetPropertyWithDetailsAsync(id);
        }

        public async Task<IEnumerable<Property>> GetPropertiesByLocationAsync(string location)
        {
            return await _propertyRepository.GetPropertiesByLocationAsync(location);
        }

        public async Task<IEnumerable<Property>> GetPropertiesWithImagesAsync()
        {
            return await _propertyRepository.GetPropertiesWithImagesAsync();
        }

        public async Task<IEnumerable<Property>> SearchPropertiesAsync(string searchTerm)
        {
            return await _propertyRepository.SearchPropertiesAsync(searchTerm);
        }

        public async Task CreatePropertyAsync(Property property)
        {
            await _propertyRepository.AddAsync(property);
            await _propertyRepository.SaveChangesAsync();
        }

        public async Task UpdatePropertyAsync(Property property)
        {
            _propertyRepository.Update(property);
            await _propertyRepository.SaveChangesAsync();
        }

        public async Task DeletePropertyAsync(int id)
        {
            var property = await _propertyRepository.GetByIdAsync(id);
            if (property != null)
            {
                _propertyRepository.Remove(property);
                await _propertyRepository.SaveChangesAsync();
            }
        }
    }
}