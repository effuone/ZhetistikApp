using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhetistikApp.Api.Models
{
    [Table("AchievementTypes")]
    public class AchievementType
    {
        [Key]
        public int AchievementTypeID { get; set; }
        public string AchievementTypeName { get; set; }

        public AchievementType(int achievementTypeID, string achievementTypeName)
        {
            AchievementTypeID = achievementTypeID;
            AchievementTypeName = achievementTypeName;
        }

        public AchievementType()
        {
        }
    }
}
