using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhetistikApp.Api.DTOs.Achievement;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementTypeRepository _achievementTypeRepository;
        private readonly IAchievementRepository _achievementRepository;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<AchievementController> _logger;

        public AchievementController(IAchievementTypeRepository achievementTypeRepository, IAchievementRepository achievementRepository, IWebHostEnvironment env, ILogger<AchievementController> logger)
        {
            _achievementTypeRepository = achievementTypeRepository;
            _achievementRepository = achievementRepository;
            _env = env;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Achievement>> GetAchievementsAsync()
        {
            return await _achievementRepository.GetAllAchievementsAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AchievementDTO>> GetAchievementAsync(int id)
        {
            var existingAchievement = await _achievementRepository.GetAchievementByIdAsync(id);
            if (existingAchievement is null)
            {
                return NotFound();
            }
            var achievement = new AchievementDTO();
            achievement.AchievementName = (await _achievementTypeRepository.GetAchievementTypeAsync(existingAchievement.AchievementTypeID)).AchievementTypeName;
            achievement.Description = existingAchievement.Description;
            achievement.Date = existingAchievement.AchievementDate.Date;
            if(existingAchievement.Score is not null)
            {
                achievement.Score = existingAchievement.Score;
            }
            if(existingAchievement.Image is not null)
            {
                achievement.Image = existingAchievement.Image;
            }
            if(existingAchievement.URL is not null)
            {
                achievement.URL = existingAchievement.URL;
            }
            _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")} : Retrieved {achievement.AchievementName}");
            return achievement;
        }
        [HttpPost]
        public async Task<ActionResult<AchievementDTO>> CreateAchievementAsync(AchievementDTO achievementDTO)
        {
            var existingAchievementType = await _achievementTypeRepository.GetAchievementTypeAsync(achievementDTO.AchievementName);
            if(existingAchievementType is null)
            {
                return NotFound();
            }
            var achievement = new Achievement();
            achievement.AchievementTypeID = (await _achievementTypeRepository.GetAchievementTypeAsync(achievementDTO.AchievementName)).AchievementTypeID;
            achievement.Description = achievementDTO.Description;
            achievement.AchievementDate = achievementDTO.Date;
            if (achievementDTO.Score is not null)
            {
                achievement.Score = achievementDTO.Score;
            }
            if (achievementDTO.Image is not null)
            {
                achievement.Image = achievementDTO.Image;
            }
            if (achievementDTO.URL is not null)
            {
                achievement.URL = achievementDTO.URL;
            }

            achievement.AchievementID = await _achievementRepository.CreateAchievementAsync(achievement);
            return CreatedAtAction(nameof(GetAchievementAsync), new { id = achievement.AchievementID }, achievement);
        }

        [Route("saveFile")]
        [HttpPost]
        public async Task<JsonResult> SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;
                using(var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    await postedFile.CopyToAsync(stream);
                }
                return new JsonResult(fileName);
            }
            catch (Exception)
            {
                return new JsonResult("none.png");
            }
        }
    }
}
