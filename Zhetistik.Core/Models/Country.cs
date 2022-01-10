using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set;}
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string CountryName { get; set; }
    }
}
