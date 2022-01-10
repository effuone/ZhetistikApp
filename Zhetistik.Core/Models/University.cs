using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Models
{
    public class University
    {
        [Key]
        public int UniversityID { get; set; }
        public int UniversityTypeID { get; set;}
        [Index(IsUnique = true)]
        public string UniversityName { get; set; }
        public DateTime FoundationYear { get; set; }
        [ForeignKey("Location")]
        public int LocationID { get; set; }
        [ForeignKey("Faculty")]
        public int FacultyID { get; set; }
        [ForeignKey("File")]
        public int FileID { get; set; }
    }
}
