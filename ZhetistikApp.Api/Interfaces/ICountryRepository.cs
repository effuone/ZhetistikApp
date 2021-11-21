using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface ICountryRepository
    {
        public Task<Country> GetCountryAsync(int countryId);
        public Task<Country> GetCountryAsync(string countryName);
        public Task<int> CreateCountryAsync(Country country);
        public Task<bool> DeleteCountryAsync(int id);
        public Task<int> UpdateCountryAsync(int id, Country country);
    }
}
