using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IUniversityTypeRepository
    {
        public Task<UniversityType> GetUniversityTypeAsync(int universityTypeId);
        public Task<UniversityType> GetUniversityTypeAsync(string universityTypeName);
        public Task<IEnumerable<UniversityType>> GetUniversityTypesAsync();
        public Task<int> CreateUniversityTypeAsync(string universityTypeName);
        public Task DeleteUniversityTypeAsync(int id);
        public Task UpdateUniversityTypeAsync(int id, string universityTypeName);
    }
}
