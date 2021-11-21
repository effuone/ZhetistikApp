using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Universities")]
    public class University
    {
        [Key]
        public long UniversityID { get; set; }
        public string UniversityName { get; set; }
        public string UniversityDescription { get; set; }
        public long LocationID { get; set; }
        public DateOnly FoundationYear { get; set; }
        public long UniversityTypeID { get; set; }
        public int StudentsCount { get; set; }

    }
}
