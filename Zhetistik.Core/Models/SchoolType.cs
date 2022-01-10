using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Models
{
    public class SchoolType
    {
        [Key]
        public int TypeID { get; set; }
        [Index(IsUnique = true)]
        public string TypeName { get; set; }
    }
}
