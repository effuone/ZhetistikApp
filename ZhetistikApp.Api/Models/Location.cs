using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        public int CityID { get; set; }
        public int CountryID { get; set; }

        public Location(int locationId, int countryId, int cityId)
        {
            LocationID = locationId;
            CityID = cityId;
            CountryID = countryId;
        }

        public Location()
        {
        }
    }
}
