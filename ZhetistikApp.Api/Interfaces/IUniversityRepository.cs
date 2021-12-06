using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IUniversityRepository
    {
        //Get university by id
        //Get universities by faculty
        //Get universities by courses
        //Get universities by year
        //Get universities by type
        //Create university
        //Update university
        //Delete university
        Task<University> GetUniversityAsync(int id);
        Task<University> GetUniversityAsync(string universityName);
        Task<IEnumerable<University>> GetUniversitiesAsync();
        Task<int> CreateUniversityAsync(University university);
        Task UpdateUniversityAsync(int id, University university);
        Task DeleteUniversityAsync(int id);
    }
}
