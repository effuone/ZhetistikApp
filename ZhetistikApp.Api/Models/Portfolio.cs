using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Portfolios")]
    public class Portfolio
    {
        [Key]
        public int PortfolioID { get; set; }
        public int CandidateID { get; set; }
        public int PlacementID { get; set; }
        public int AchievementID { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsPublished { get; set; }
        public Portfolio()
        {

        }
    }
}
