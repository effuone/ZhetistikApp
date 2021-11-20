using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Repositories
{
    public class PlacementRepository : IPlacementRepository
    {
        private readonly DapperContext _context;

        public PlacementRepository(DapperContext context)
        {
            _context = context;
        }

        public Task<int> CreateCityAsync(Country country)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateCountryAsync(Country country)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreatePlacementAsync(Placement placement)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCountryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeletePlacementAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Placement> GetCityAsync(int cityId)
        {
            throw new NotImplementedException();
        }

        public Task<Placement> GetCountryAsync(int countryId)
        {
            throw new NotImplementedException();
        }

        public Task<Placement> GetPlacementAsync(int placementId)
        {
            throw new NotImplementedException();
        }

        public Task<Placement> GetPlacementAsync(string cityName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Placement>> GetPlacementsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCityAsync(int id, Placement placement)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCountryAsync(int id, Placement placement)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlacementAsync(int id, Placement placement)
        {
            throw new NotImplementedException();
        }
    }
}
