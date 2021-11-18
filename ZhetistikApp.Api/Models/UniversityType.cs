using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("UniversityTypes")]
    public class UniversityType
    {
        [Key]
        public long UniversityTypeID { get; set; }
        public string UniversityTypeName { get; set; }
    }
}
