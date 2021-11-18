using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface ICourseRepository
    {
        //GET course by id
        //GET courses by name
        //GET courses by length
        //GET courses by university
        //CREATE course
        //UPDATE course
        //DELETE course
        Task<Course> GetCourseByIdAsync(long id);
        Task<IEnumerable<Course>> GetCoursesByNameAsync(string courseName);
        Task<IEnumerable<Course>> GetCoursesByLengthAsync(int length);
        Task<IEnumerable<Course>> GetCoursesByUniversityAsync(int length);
        Task<long> CreateCourseAsync(Course course);
    }
}
