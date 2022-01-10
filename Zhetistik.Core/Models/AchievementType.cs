using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Models
{
    public class AchievementType
    {
        [Key]
        public int TypeID { get; set; }
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string TypeName { get; set; }
    }
}
