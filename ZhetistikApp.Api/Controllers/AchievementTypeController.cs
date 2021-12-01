using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/achievementTypes/")]
    [ApiController]
    public class AchievementTypeController : ControllerBase
    {
        private readonly IAchievementTypeRepository _achievementRepository;
        private readonly ILogger<AchievementTypeController> _logger;

        public AchievementTypeController(IAchievementTypeRepository achievementRepository, ILogger<AchievementTypeController> logger)
        {
            _achievementRepository = achievementRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<AchievementType>> GetAchievementTypesAsync()
        {
            return await _achievementRepository.GetAchievementTypesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AchievementType>> GetAchievementAsync(int id)
        {
            var country = await _achievementRepository.GetAchievementTypeAsync(id);
            if (country is null)
            {
                return NotFound();
            }
            return country;
        }
        [HttpPost]
        public async Task<ActionResult<AchievementType>> CreateAchievementAsync(string achievementTypeName)
        {
            var existingType = await _achievementRepository.GetAchievementTypeAsync(achievementTypeName);
            if (existingType is null)
            {
                var type = new AchievementType();
                type.AchievementTypeName = achievementTypeName;
                type.AchievementTypeID = await _achievementRepository.CreateAchievementTypeAsync(achievementTypeName);
                return CreatedAtAction(nameof(CreateAchievementAsync), new { id = type.AchievementTypeID }, type);
            }
            return StatusCode(409, $"Achievement type {achievementTypeName} already exists");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<AchievementType>> UpdateAchievementTypeAsync(int id, string achievementTypeName)
        {
            var existingType = await _achievementRepository.GetAchievementTypeAsync(id);
            if (existingType is null)
            {
                return NotFound();
            }
            await _achievementRepository.UpdateAchievementTypeAsync(id, achievementTypeName);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAchievementTypeAsync(int id)
        {
            var existingType = await _achievementRepository.GetAchievementTypeAsync(id);
            if (existingType is null)
            {
                return NotFound();
            }
            await _achievementRepository.DeleteAchievementTypeAsync(id);
            return NoContent();
        }
    }
}
