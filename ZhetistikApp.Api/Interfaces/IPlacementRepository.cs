using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IPlacementRepository
    {
        public Task<Placement> GetPlacementAsync(int placementId);
        public Task<Placement> GetCountryAsync(int countryId);
        public Task<Placement> GetCityAsync(int cityId);
        public Task<Placement> GetPlacementAsync(string cityName);
        public Task<IEnumerable<Placement>> GetPlacementsAsync();
        public Task<int> CreatePlacementAsync(Placement placement);
        public Task<int> CreateCountryAsync(Country country);
        public Task<int> CreateCityAsync(Country country);
        public Task DeletePlacementAsync(int id);
        public Task DeleteCountryAsync(int id);
        public Task DeleteCityAsync(int id);
        public Task UpdatePlacementAsync(int id, Placement placement);
        public Task UpdateCountryAsync(int id, Placement placement);
        public Task UpdateCityAsync(int id, Placement placement);
    }
}
