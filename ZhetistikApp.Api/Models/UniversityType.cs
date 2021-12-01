using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("UniversityTypes")]
    public class UniversityType
    {
        [Key]
        public int UniversityTypeID { get; set; }

        public string UniversityTypeName { get; set; }
        public UniversityType()
        {

        }

        public UniversityType(int universityTypeID, string universityTypeName)
        {
            UniversityTypeID = universityTypeID;
            UniversityTypeName = universityTypeName;
        }
    }

}
