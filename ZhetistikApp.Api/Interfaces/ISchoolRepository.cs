using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface ISchoolRepository
    {
        //GET school by name
        //GET school by year
        //GET schools by placement
        //GET schools
        //CREATE school 
        //UPDATE school
        //DELETE school
        Task<School> GetSchoolByIdAsync(int id);
        Task<School> GetSchoolByNameAsync(string schoolName);
        Task<IEnumerable<School>> GetAllSchoolsAsync();
        Task<IEnumerable<School>> GetSchoolsByLocationAsync();
        Task<IEnumerable<School>> GetSchoolsByYearAsync(int year);
        Task<int> CreateSchoolAsync(School school);
        Task UpdateSchoolAsync(School school);
        Task DeleteSchoolAsync(int id);
    }
}
