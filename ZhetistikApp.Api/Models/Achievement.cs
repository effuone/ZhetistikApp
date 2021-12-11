using Dapper.Contrib.Extensions;

namespace ZhetistikApp.Api.Models
{
    [Table("Achievements")]
    public class Achievement
    {
        [Key]
        public int AchievementID { get; set; }
        [ExplicitKey]
        public int AchievementTypeID { get; set; }
        public string Description { get; set; }
        public DateTime AchievementDate { get; set; }
        public int? Score { get; set; }
        public byte[] Image { get; set; }
        public string URL { get; set; }
        public Achievement()
        {

        }
        public Achievement(int achievementID, int achievementTypeID, string description, DateTime achievementDate, int? score, byte[] image, string uRL)
        {
            AchievementID = achievementID;
            AchievementTypeID = achievementTypeID;
            Description = description;
            AchievementDate = achievementDate;
            Score = score;
            Image = image;
            URL = uRL;
        }
    }
}
