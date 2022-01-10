using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhetistik.Core.Common;

namespace Zhetistik.Core.Models
{
    public class Portfolio
    {
        [Key]
        public int PortfolioID { get; set; }
        [ForeignKey("Candidate")]
        public int CandidateID { get; set; }
        [ForeignKey("Achievement")]
        public int AchievementID { get; set;}
        [ForeignKey("Letter")]
        public int LetterID { get; set; }
        [ForeignKey("Extracurricular")]
        public int ExtracurricularID { get; set; }
        [ForeignKey("FinancialDoc")]
        public int FinancialDocID { get; set; }
        public bool IsPublished { get; set; }
        public int Visits { get; set; }
    }
}
