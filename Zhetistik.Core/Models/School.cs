using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Models
{
    public class School
    {
        [Key]
        public int SchoolID { get; set; }
        [Index(IsUnique = true)]
        public string SchoolName { get; set; }
        public string Description { get; set; }
        public DateTime FoundationYear { get; set; }
        [ForeignKey("SchoolType")]
        public int SchoolTypeID { get; set; }
        [ForeignKey("Location")]
        public int LocationID { get; set; }
        [ForeignKey("FileStructure")]
        public int FileID { get; set; }
    }
}
