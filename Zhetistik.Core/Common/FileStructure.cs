using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Common
{
    [Table("FileStructures")]
    public class FileStructure
    {
        [Key]
        public int FileID { get; set;}
        [MaxLength(1000)]
        public string FileName { get; set; }
        [MaxLength(10000)]
        public string PhysicalPath { get; set; }
    }
}
