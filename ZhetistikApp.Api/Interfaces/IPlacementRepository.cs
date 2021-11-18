using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IPlacementRepository
    {
        public Task<Placement> GetPlacementAsync(int placementId);
        public Task<Placement> GetPlacementAsync(int countryId, int cityId);
        public Task<IEnumerable<Placement>> GetPlacementsAsync();
        public Task<int> CreatePlacementAsync(Placement placement);
        public Task DeletePlacementAsync(int id);
        public Task UpdatePlacementAsync();
    }
}
