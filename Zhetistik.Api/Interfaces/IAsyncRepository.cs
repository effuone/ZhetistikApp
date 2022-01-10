namespace Zhetistik.Api.Interfaces
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> CreateAsync(T model);
        Task<bool> UpdateAsync(int id, T model);
        Task<bool> DeleteAsync(int id);
    }
}
