using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public long CityID { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }
    }
}
