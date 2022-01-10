using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IFileable
    {
        public Task<FileStruct> GetFileAsync(string path);
        public Task<FileStruct> GetFileAsync(int id);
        public Task<IEnumerable<FileStruct>> GetFilesAsync();
        public Task UpdateFileAsync(int id, FileStruct file);
        public Task DeleteFileAsync(int id);
    }
}
