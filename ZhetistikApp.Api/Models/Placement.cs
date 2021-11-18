using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Placements")]
    public class Placement
    {
        [Key]
        public long PlacementID { get; set; }
        public long CountryID { get; set; }
        public long CityID { get; set; }
    }
}
