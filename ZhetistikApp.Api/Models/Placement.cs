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
        public int StateID { get; set; }

        public Location(int locationID, int cityID, int countryID, int stateID)
        {
            LocationID = locationID;
            CityID = cityID;
            CountryID = countryID;
            StateID = stateID;
        }
    }
}
