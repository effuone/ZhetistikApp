using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("Achievements")]
    public class Achievement
    {
        [Key]
        public int AchievementID { get; set; }
        public int AchievementTypeID { get; set; }
        public int? Score { get; set; }
        public byte[] Image { get; set; }
        public string URL { get; set; }
        public Achievement()
        {

        }

        public Achievement(int achievementID, int achievementTypeID, int? score, byte[] image, string uRL)
        {
            AchievementID = achievementID;
            AchievementTypeID = achievementTypeID;
            Score = score;
            Image = image;
            URL = uRL;
        }
    }
}
