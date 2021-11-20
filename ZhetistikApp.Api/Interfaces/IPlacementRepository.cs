using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IPlacementRepository
    {
        public Task<Placement> GetPlacementAsync(int placementId);
        public Task<Country> GetCountryAsync(int countryId);
        public Task<City> GetCityAsync(int cityId);
        public Task<Placement> GetPlacementAsync(string cityName);
        public Task<IEnumerable<Placement>> GetPlacementsAsync();
        public Task<int> CreatePlacementAsync(Placement placement);
        public Task<int> CreateCountryAsync(Country country);
        public Task<int> CreateCityAsync(City city);
        public Task<bool> DeletePlacementAsync(int id);
        public Task<bool> DeleteCountryAsync(int id);
        public Task<bool> DeleteCityAsync(int id);
        public Task<int> UpdatePlacementAsync(int id, Placement placement);
        public Task<int> UpdateCountryAsync(int id, Country country);
        public Task<int> UpdateCityAsync(int id, City city);
    }
}
