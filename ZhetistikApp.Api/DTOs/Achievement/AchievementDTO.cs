namespace ZhetistikApp.Api.DTOs.Achievement
{
    public class AchievementDTO
    {
        public string AchievementName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? Score { get; set; } = null;
        public byte[]? Image { get; set; } = null;
        public string? URL { get; set; } = null;
        public AchievementDTO()
        {

        }

        public AchievementDTO( string achievementName, string description, DateTime date, int? score = null, byte[] image = null, string uRL = null)
        {
            AchievementName = achievementName;
            Description = description;
            Date = date;
            Score = score;
            Image = image;
            URL = uRL;
        }
    }
}
