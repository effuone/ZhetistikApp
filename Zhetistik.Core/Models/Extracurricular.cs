using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Models
{
    public class Extracurricular
    {
        [Key]
        public int ExtracurricularID { get; set; }
        [MaxLength(50)]
        public string Name { get; set;}
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [ForeignKey("FileStructure")]
        public int FileID { get; set; }
    }
}
