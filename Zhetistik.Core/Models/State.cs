using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Models
{
    public class State
    {
        [Key]
        public int StateID { get; set; }
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        [Index(IsUnique = true)]
        public string StateName { get; set; }
    }
}
