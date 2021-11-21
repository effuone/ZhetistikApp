using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface ICityRepository
    {
        public Task<City> GetCityAsync(int cityId);
        public Task<City> GetCityAsync(string cityName);
        public Task<int> CreateCityAsync(City city);
        public Task<bool> DeleteCityAsync(int id);
        public Task<int> UpdateCityAsync(int id, City city);
    }
}
