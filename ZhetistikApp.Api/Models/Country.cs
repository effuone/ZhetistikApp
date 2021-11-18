using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }
}
