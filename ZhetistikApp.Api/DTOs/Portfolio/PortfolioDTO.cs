using System.ComponentModel.DataAnnotations;

namespace ZhetistikApp.Api.DTOs.Portfolio
{
    public record PortfolioDTO(
    int portfolioID,
    int candidateID,
    int placementID,
    int achievementID,
    DateTime createdDate,
    bool ispublished
    );
    public record CreatePortfolioDTO(
    [Required] int CandidateID,
    [Required] int PlacementID,
    [Required] int AchievementID,
    [Required] DateTime CreatedDate,
    [Required] bool IsPublished
    );
    public record UpdatePortfolioDTO(
    [Required] int CandidateID,
    [Required] int PlacementID,
    [Required] int AchievementID,
    [Required] DateTime CreatedDate,
    [Required] bool IsPublished
    );
}
