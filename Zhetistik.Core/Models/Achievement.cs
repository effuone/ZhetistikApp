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
    public class Achievement
    {
        [Key]
        public int AchievementID { get; set; }
        [ForeignKey("AchievementType")]
        public int AchievementTypeID { get; set; }
        public string Description { get; set; }
        public DateTime AchievementDate { get; set; }
        public int Score { get; set; }
        [ForeignKey("FileStructure")]
        public int? FileID { get; set; }
    }
}
