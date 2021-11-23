using ZhetistikApp.Api.DTOs.Placement;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface ICityRepository
    {
        public Task<City> GetCityAsync(int cityId);
        public Task<City> GetCityAsync(string cityName);
        public Task<IEnumerable<City>> GetCitiesAsync();
        public Task<int> CreateCityAsync(City city);
        public Task DeleteCityAsync(int id);
        public Task UpdateCityAsync(int id, City city);
    }
}
