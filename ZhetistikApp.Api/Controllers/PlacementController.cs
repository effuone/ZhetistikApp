using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhetistikApp.Api.DTOs.Placement;
using ZhetistikApp.Api.Interfaces;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/placements")]
    [ApiController]
    public class PlacementController : ControllerBase
    {
        private readonly IPlacementRepository _placementRepository;
        public PlacementController(IPlacementRepository placementRepository)
        {
            _placementRepository = placementRepository;
        }
        [HttpGet]
        public async Task<ActionResult<PlacementDTO>> GetAllPlacementsAsync()
        {
            try
            {
                var candidates = await _placementRepository.GetPlacementsAsync();
                return Ok(candidates);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
