using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface ICountryRepository
    {
        public Task<Country> GetCountryAsync(int countryId);
        public Task<Country> GetCountryAsync(string countryName);
        public Task<IEnumerable<Country>> GetCountriesAsync();
        public Task<Country> GetCountryByCityAsync(string cityName);
        public Task<int> CreateCountryAsync(Country country);
        public Task DeleteCountryAsync(int id);
        public Task UpdateCountryAsync(int id, Country country);
    }
}
