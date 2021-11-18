using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IAchievementRepository
    {
        public Task<Achievement> GetAchievementByIdAsync(int id);
        public Task<IEnumerable<Achievement>> GetAllAchievementsAsync();
        public Task<IEnumerable<Achievement>> GetAchievementsByPersonAsync(string firstName, string lastName);
        public Task<int> CreateAchievementAsync(Achievement achievement);
        public Task DeleteAchievementAsync(int id);
        public Task UpdateAchievementAsync(Achievement achievement);
    }
}
