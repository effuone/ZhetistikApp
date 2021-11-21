using ZhetistikApp.Api.Models;
using ZhetistikApp.Api.ViewModels;

namespace ZhetistikApp.Api.Interfaces
{
    public interface ILocationRepository
    {
        //Locations
        public Task<Location> GetLocationAsync(int locationId);
        public Task<LocationViewModel> GetLocationViewModelAsync(int locationId);
        public Task<Location> GetLocationAsync(string cityName);
        public Task<IEnumerable<LocationViewModel>> GetLocationViewModelByCityAsync(string cityName);
        public Task<IEnumerable<LocationViewModel>> GetLocationViewModelsAsync();
        public Task<IEnumerable<Location>> GetLocationsAsync();
        public Task<int> CreateLocationAsync(Location location);
        public Task<bool> DeleteLocationAsync(int id);
        public Task<int> UpdateLocationAsync(int id, Location placement);
    }
}
