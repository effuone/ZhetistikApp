using System.ComponentModel.DataAnnotations;

namespace ZhetistikApp.Api.DTOs.Location
{
    public class LocationDTO
    {
        public LocationDTO()
        {
        }

        public LocationDTO(int locationId, string countryName, string stateName, string cityName)
        {

            LocationID = locationId;
            CountryName = countryName;
            StateName = stateName;
            CityName = cityName;
        }

        public int LocationID { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
    }
    public class CreateLocationDTO
    {
        [Required] public string CountryName { get; set; } 
        [Required] public string StateName { get; set; } 
        [Required] public string CityName { get; set; }

        public CreateLocationDTO(string countryName, string stateName, string cityName)
        {
            CountryName = countryName;
            StateName = stateName;
            CityName = cityName;
        }
    }
    public class UpdateLocationDTO
    {
        [Required] public string CountryName { get; set; }
        [Required] public string StateName { get; set; }
        [Required] public string CityName { get; set; }

        public UpdateLocationDTO(string countryName, string stateName, string cityName)
        {
            CountryName = countryName;
            StateName = stateName;
            CityName = cityName;
        }
    }
}
