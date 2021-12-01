using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/universityTypes/")]
    [ApiController]
    public class UniversityTypeController : ControllerBase
    {
        private readonly IUniversityTypeRepository _universityRepository;
        private readonly ILogger<UniversityTypeController> _logger;

        public UniversityTypeController(IUniversityTypeRepository universityRepository, ILogger<UniversityTypeController> logger)
        {
            _universityRepository = universityRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<UniversityType>> GetUnivesityTypesAsync()
        {
            return await _universityRepository.GetUniversityTypesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UniversityType>> GetUniversityTypeAsync(int id)
        {
            var type = await _universityRepository.GetUniversityTypeAsync(id);
            if (type is null)
            {
                return NotFound();
            }
            return type;
        }
        [HttpPost]
        public async Task<ActionResult<UniversityType>> CreateUniversityTypeAsync(string universityTypeName)
        {
            var existingType = await _universityRepository.GetUniversityTypeAsync(universityTypeName);
            if (existingType is null)
            {
                var type = new UniversityType();
                type.UniversityTypeName = universityTypeName;
                type.UniversityTypeID = await _universityRepository.CreateUniversityTypeAsync(universityTypeName);
                return CreatedAtAction(nameof(CreateUniversityTypeAsync), new { id = type.UniversityTypeID }, type);
            }
            return StatusCode(409, $"University type {universityTypeName} already exists");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UniversityType>> UpdateAchievementTypeAsync(int id, string universityTypeName)
        {
            var existingType = await _universityRepository.GetUniversityTypeAsync(id);
            if (existingType is null)
            {
                return NotFound();
            }
            await _universityRepository.UpdateUniversityTypeAsync(id, universityTypeName);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUniversityTypeAsync(int id)
        {
            var existingType = await _universityRepository.GetUniversityTypeAsync(id);
            if (existingType is null)
            {
                return NotFound();
            }
            await _universityRepository.DeleteUniversityTypeAsync(id);
            return NoContent();
        }
    }
}
