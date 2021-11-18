using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Faculties")]
    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }
        public int CourseID { get; set; }
        public int UniversityID { get; set; }
    }
}
