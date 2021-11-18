using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IFacultyRepository
    {
        //GET faculty by id
        //GET faculties by name
        //GET faculty by course
        //GET faculties by university
        //CREATE course
        //UPDATE course
        //DELETE course
        Task<Faculty> GetFacultyAsync(long id);
        Task<IEnumerable<Faculty>> GetFacultiesByNameAsync(string facultyName);
        Task<IEnumerable<Faculty>> GetAllFacultiesAsync();
        Task<IEnumerable<Faculty>> GetFacultiesByUniversityAsync(long universityId);
        Task<long> CreateFacultyAsync(Faculty faculty);
        Task DeleteFacultyAsync(long id);
        Task UpdateFacultyAsync(Faculty faculty);
    }
}
