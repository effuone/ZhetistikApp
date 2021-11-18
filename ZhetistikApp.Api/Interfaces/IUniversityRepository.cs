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
        Task<IEnumerable<University>> GetUniversitiesByFaculty(string facultyName);
        Task<IEnumerable<University>> GetUniversitiesByCourse(string courseName);
        Task<IEnumerable<University>> GetUniversitiesByYear(int year);
        Task<IEnumerable<University>> GetUniversitiesByType(string type);
        Task<int> CreateUniversityAsync(University university);
        Task UpdateUniversityAsync(University university);
        Task DeleteUniversityAsync(int id);
    }
}
