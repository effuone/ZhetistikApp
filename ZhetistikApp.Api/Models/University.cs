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
        public int LocationID { get; set; }
        public DateTime FoundationYear { get; set; }
        public int UniversityTypeID { get; set; }
        public int StudentsCount { get; set; }

        public University()
        {

        }
        public University(int universityID, string universityName, string universityDescription, int locationID, DateTime foundationYear, int universityTypeID, int studentsCount)
        {
            UniversityID = universityID;
            UniversityName = universityName;
            UniversityDescription = universityDescription;
            LocationID = locationID;
            FoundationYear = foundationYear;
            UniversityTypeID = universityTypeID;
            StudentsCount = studentsCount;
        }
    }
}
