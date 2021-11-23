using System.ComponentModel.DataAnnotations;

namespace ZhetistikApp.Api.DTOs.Placement
{
    public class CityDTO {
        public int CityID { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
    }

    public class CreateCityDTO
    {
        [Required]
        public string CountryName { get; set; }
        [Required]
        public string CityName { get; set; }
    }
    public class UpdateCityDTO
    {
        [Required]
        public string CountryName { get; set; }
        [Required]
        public string CityName { get; set; }
    }
}
