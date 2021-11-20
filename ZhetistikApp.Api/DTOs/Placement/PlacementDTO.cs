using System.ComponentModel.DataAnnotations;

namespace ZhetistikApp.Api.DTOs.Placement
{
    public class PlacementDTO
    {
        public int PlacementID { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }
        public string CountryName { get; set; }
    }
    public class CreatePlacementDTO
    {
        [Required] public string CityName { get; set; } 
        [Required] public string PostalCode { get; set; } 
        [Required] public string CountryName { get; set; }
    }
    public class UpdatePlacementDTO
    {
        [Required] public string CityName { get; set; }
        [Required] public string PostalCode { get; set; }
        [Required] public string CountryName { get; set; }
    }
}
