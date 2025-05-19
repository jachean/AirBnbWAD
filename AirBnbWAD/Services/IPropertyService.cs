using AirBnbWAD.Models;

namespace AirBnbWAD.Services
{
    public interface IPropertyService
    {
        Task<IEnumerable<Property>> GetAllPropertiesAsync();
        Task<Property> GetPropertyByIdAsync(int id);
        Task<Property> GetPropertyWithDetailsAsync(int id);
        Task<IEnumerable<Property>> GetPropertiesByLocationAsync(string location);
        Task<IEnumerable<Property>> GetPropertiesWithImagesAsync();
        Task<IEnumerable<Property>> SearchPropertiesAsync(string searchTerm);
        Task CreatePropertyAsync(Property property);
        Task UpdatePropertyAsync(Property property);
        Task DeletePropertyAsync(int id);
    }
}