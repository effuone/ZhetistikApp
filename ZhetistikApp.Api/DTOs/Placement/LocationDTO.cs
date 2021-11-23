using System.ComponentModel.DataAnnotations;

namespace ZhetistikApp.Api.DTOs.Location
{
    public class LocationDTO
    {
        public LocationDTO()
        {
        }

        public LocationDTO(int locationId, string countryName, string cityName)
        {

            LocationID = locationId;
            CountryName = countryName;
            CityName = cityName;
        }

        public int LocationID { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
    }
    public class CreateLocationDTO
    {
        [Required] public string CountryName { get; set; } 
        [Required] public string CityName { get; set; }

        public CreateLocationDTO(string countryName, string cityName)
        {
            CountryName = countryName;
            CityName = cityName;
        }
    }
    public class UpdateLocationDTO
    {
        [Required] public string CountryName { get; set; }
        [Required] public string CityName { get; set; }

        public UpdateLocationDTO(string countryName, string cityName)
        {
            CountryName = countryName;
            CityName = cityName;
        }
    }
}
