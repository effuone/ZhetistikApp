using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface ILocationRepository
    {
        //Locations
        public Task<Location> GetLocationAsync(int locationId);
        public Task<Location> GetLocationAsync(string cityName);
        public Task<IEnumerable<Location>> GetLocationsAsync();
        public Task<int> CreateLocationAsync(Location location);
        public Task DeleteLocationAsync(int id);
        public Task UpdateLocationAsync(int id, Location location);
    }
}
