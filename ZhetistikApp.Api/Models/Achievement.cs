namespace ZhetistikApp.Api.Models
{
    public class Achievement
    {
        public int AchievementID { get; set; }
        public string AchievementName { get; set; }

        public int? Score { get; set; }

        public string Image { get; set; }
        public Achievement()
        {

        }

        public Achievement(int achievementID, string achievementName, int? score, string image)
        {
            AchievementID = achievementID;
            AchievementName = achievementName;
            Score = score;
            Image = image;
        }
    }
}
