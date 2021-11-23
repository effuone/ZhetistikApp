using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public int CountryID { get; set; }
        public string CityName { get; set; }


        public City(int cityID, int countryID, string cityName)
        {
            CityID = cityID;
            CountryID = countryID;
            CityName = cityName;
        }

        public City()
        {
        }
    }
}
