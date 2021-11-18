using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Portfolios")]
    public class Portfolio
    {
        [Key]
        public long PortfolioID { get; set; }
        public long CandidateID { get; set; }
        public long PlacementID { get; set; }
        public long AchievementID { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsPublished { get; set; }
        public Portfolio()
        {

        }
    }
}
