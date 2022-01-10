using ZhetistikApp.Api.DataAccess;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Repositories
{
    public class FileRepository : IFileable
    {
        private readonly DapperContext _context;

        public FileRepository(DapperContext context)
        {
            _context = context;
        }

        public Task DeleteFileAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FileStruct> GetFileAsync(string path)
        {
            throw new NotImplementedException();
        }

        public Task<FileStruct> GetFileAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FileStruct>> GetFilesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateFileAsync(int id, FileStruct file)
        {
            throw new NotImplementedException();
        }
    }
}
