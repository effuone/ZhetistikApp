using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IAchievementTypeRepository
    {
        public Task<AchievementType> GetAchievementTypeAsync(int achievementTypeId);
        public Task<AchievementType> GetAchievementTypeAsync(string achievementTypeName);
        public Task<IEnumerable<AchievementType>> GetAchievementTypesAsync();
        public Task<int> CreateAchievementTypeAsync(string achievementTypeName);
        public Task DeleteAchievementTypeAsync(int id);
        public Task UpdateAchievementTypeAsync(int id, string achievementTypeName);
        //rezyme 
        //gpa
        //sat
        //ielts
        //extracurriculars
        //achievements
        //3 recommendations
        //interview and preparation
    }
}
