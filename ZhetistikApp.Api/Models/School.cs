using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Schools")]
    public class School
    {
        [Key]
        public int SchoolID { get; set; }
        public int LocationID { get; set; }
        public string SchoolName { get; set; }
        public DateTime FoundationYear { get; set; }
    }
}
