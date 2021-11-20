using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Placements")]
    public class Placement
    {
        [Key]
        public int PlacementID { get; set; }
        public int CityID { get; set; }

        public Placement(int placementID, int cityID)
        {
            PlacementID = placementID;
            CityID = cityID;
        }
    }
}
