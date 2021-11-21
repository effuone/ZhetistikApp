using System.ComponentModel.DataAnnotations;

namespace ZhetistikApp.Api.DTOs.Placement
{
    public class CityDTO {
        [Required]
        public int CityID { get; set; }
        [Required]
        public string CountryName { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string PostalCode { get; set; }
    }

    public class CreateCityDTO
    {
        [Required]
        public string CountryName { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string PostalCode { get; set; }
    }
    public class UpdateCityDTO
    {
        [Required]
        public string CountryName { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]        
        public string PostalCode { get; set; }
    }
}
