using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseLength { get; set; }
        [ForeignKey("FileStructure")]
        public int FileID { get; set; }
    }
}
