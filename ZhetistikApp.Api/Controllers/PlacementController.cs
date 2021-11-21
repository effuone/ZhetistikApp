using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhetistikApp.Api.DTOs.Location;
using ZhetistikApp.Api.DTOs;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.ViewModels;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/Locations")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILocationRepository LocationRepository, ILogger<LocationController> logger)
        {
            _locationRepository = LocationRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<LocationDTO>> GetAllLocationsAsync()
        {
            var locations = (await _locationRepository.GetLocationViewModelsAsync()).Select(x => x.AsDto());
            _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")} : Retrieved {locations.Count()} locations");
            return locations;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDTO>> GetLocationAsync(int id)
        {
            var Location = await _locationRepository.GetLocationViewModelAsync(id);
            if (Location is null)
            {
                return NotFound();
            }
            return Location.AsDto();
        }
        [HttpGet("{cityName}")]
        public async Task<IEnumerable<LocationDTO>> GetLocationByCityAsync(string cityName)
        {
            var locations = await _locationRepository.GetLocationViewModelByCityAsync(cityName);
            _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")} : Retrieved {locations.Count()} locations");
            return locations.AsDto();
        }
    }
}
