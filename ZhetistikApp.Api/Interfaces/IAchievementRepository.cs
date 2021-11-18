using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IAchievementRepository
    {
        public Task<Achievement> GetAchievementByIdAsync(long id);
        public Task<IEnumerable<Achievement>> GetAllAchievementsAsync();
        public Task<IEnumerable<Achievement>> GetAchievementsByPersonAsync(string firstName, string lastName);
        public Task<long> CreateAchievementAsync(Achievement achievement);
        public Task DeleteAchievementAsync(long id);
        public Task UpdateAchievementAsync(Achievement achievement);
    }
}
