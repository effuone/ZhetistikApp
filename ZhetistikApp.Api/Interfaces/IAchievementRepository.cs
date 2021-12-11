using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IAchievementRepository
    {
        public Task<Achievement> GetAchievementByIdAsync(int id);
        public Task<IEnumerable<Achievement>> GetAllAchievementsAsync();
        public Task<int> CreateAchievementAsync(Achievement achievement);
        public Task<bool> DeleteAchievementAsync(int id);
        public Task<bool> UpdateAchievementAsync(int id, Achievement achievement);
    }
}
