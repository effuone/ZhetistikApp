using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Models
{
    public class Letter
    {
        [Key]
        public int LetterID { get; set; }
        [ForeignKey("LetterType")]
        public int LetterTypeID { get; set; }
        public string Description { get; set; }
        public string WriterName { get; set; }
        public string WriterSurName { get; set; }
        [ForeignKey("File")]
        public int FileID { get; set; }
    }
}
