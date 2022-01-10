namespace ZhetistikApp.Api.Models
{
    public class FileStruct
    {
        public string FileID { get; set; }
        public string FileName { get; set; }
        public string PhysicalPath { get; set; }
        public FileStruct()
        {

        }
        public FileStruct(string fileID, string fileName, string physicalPath)
        {
            FileID = fileID;
            FileName = fileName;
            PhysicalPath = physicalPath;
        }
    }
}
