using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Models
{
    public class FinancialDoc
    {
        [Key]
        public int FinancialID { get; set; }
        [MaxLength(50)]
        public string DocumentName { get; set; }
        [ForeignKey("FileStructure")]
        public int FileID { get; set; }
    }
}
