using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Faculties")]
    public class Faculty
    {
        [Key]
        public long FacultyID { get; set; }
        public string FacultyName { get; set; }
        public long CourseID { get; set; }
        public long UniversityID { get; set; }
    }
}
