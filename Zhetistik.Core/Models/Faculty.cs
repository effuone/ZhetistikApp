using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string FacultyName { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        [ForeignKey("University")]
        public int UniversityID { get; set; }
    }
}
