using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhetistik.Core.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        [ForeignKey("State")]
        public int? StateID { get; set; }
        [ForeignKey("City")]
        public int CityID { get; set; }
    }
}
