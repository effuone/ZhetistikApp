using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateID { get; set; }
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        [ForeignKey("Location")]
        public int LocationID { get; set; }
        [ForeignKey("FileStructure")]
        public int FileID { get; set; }
    }
}
