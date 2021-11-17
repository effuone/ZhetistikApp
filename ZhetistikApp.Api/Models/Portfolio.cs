namespace ZhetistikApp.Api.Models
{
    public class Portfolio
    {
        public long PortfolioID { get; set; }
        public long CandidateID { get; set; }
        public List<Achievement> Achievements { get; set;} = new List<Achievement>();
        public PlacementInfo Location { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsPublished { get; set; }
        public Portfolio()
        {

        }
    }
}
