using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Universities")]
    public class University
    {
        [Key]
        public int UniversityID { get; set; }
        public string UniversityName { get; set; }
        public string UniversityDescription { get; set; }
        public int PlacementID { get; set; }
        public DateOnly FoundationYear { get; set; }
        public int UniversityTypeID { get; set; }
        public int StudentsCount { get; set; }

    }
}
