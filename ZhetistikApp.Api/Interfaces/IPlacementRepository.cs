using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IPlacementRepository
    {
        public Task<Placement> GetPlacementAsync(long placementId);
        public Task<Placement> GetPlacementAsync(long countryId, long cityId);
        public Task<IEnumerable<Placement>> GetPlacementsAsync();
        public Task<long> CreatePlacementAsync(Placement placement);
        public Task DeletePlacementAsync(long id);
        public Task UpdatePlacementAsync();
    }
}
