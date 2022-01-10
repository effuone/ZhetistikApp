using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        [MaxLength(40)]
        [Index(IsUnique = true)]
        public string CityName { get; set; }
    }
}
