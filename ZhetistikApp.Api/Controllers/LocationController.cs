using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhetistikApp.Api.DTOs.Location;
using ZhetistikApp.Api.DTOs;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/locations/")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILocationRepository locationRepository, ICityRepository cityRepository, ICountryRepository countryRepository, ILogger<LocationController> logger)
        {
            _locationRepository = locationRepository;
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<Location>> GetCitiesAsync()
        {
            return await _locationRepository.GetLocationsAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocationAsync(int id)
        {
            var location = await _locationRepository.GetLocationAsync(id);
            if (location is null)
            {
                return NotFound();
            }
            return location;
        }
        [HttpPost]
        public async Task<ActionResult<LocationDTO>> CreateLocationAsync(CreateLocationDTO locationDTO)
        {
            var existingCountry = await _countryRepository.GetCountryAsync(locationDTO.CountryName);
            var existingCity = await _cityRepository.GetCityAsync(locationDTO.CityName);
            if (existingCity is not null && existingCountry is not null)
            {
                var existingLocation = await _locationRepository.GetLocationAsync(existingCity.CityName);
                if (existingLocation is not null)
                {
                    return StatusCode(409, $"Location {existingLocation.LocationID} of {existingCity.CityName} in {existingCountry.CountryName} already exists");
                }
                else
                {
                    var location = new Location();
                    location.CountryID = existingCountry.CountryID;
                    location.CityID = existingCity.CityID;
                    location.LocationID = await _locationRepository.CreateLocationAsync(location);

                    var returner = new LocationDTO();
                    returner.LocationID = location.LocationID;
                    returner.CityName = existingCity.CityName;
                    returner.CountryName = existingCountry.CountryName;
                    return CreatedAtAction(nameof(CreateLocationAsync), new { id = location.LocationID }, returner);
                }
            }
            else if (existingCountry is not null && existingCity is null)
            {
                var city = new City();
                city.CountryID = existingCountry.CountryID;
                city.CityName = locationDTO.CityName;
                city.CityID = await _cityRepository.CreateCityAsync(city);

                var location = new Location();
                location.CountryID = existingCountry.CountryID;
                location.CityID = city.CityID;
                location.LocationID = await _locationRepository.CreateLocationAsync(location);

                var returner = new LocationDTO();
                returner.LocationID = location.LocationID;
                returner.CityName = existingCity.CityName;
                returner.CountryName = existingCountry.CountryName;
                return CreatedAtAction(nameof(CreateLocationAsync), new { id = location.LocationID }, returner);
            }
            else
            {
                var country = new Country();
                country.CountryName = locationDTO.CountryName;
                country.CountryID = await _countryRepository.CreateCountryAsync(country);

                var city = new City();
                city.CountryID = country.CountryID;
                city.CityName = locationDTO.CityName;
                city.CityID = await _cityRepository.CreateCityAsync(city);

                var location = new Location();
                location.CountryID = country.CountryID;
                location.CityID = city.CityID;
                location.LocationID = await _locationRepository.CreateLocationAsync(location);

                var returner = new LocationDTO();
                returner.LocationID = location.LocationID;
                returner.CityName = city.CityName;
                returner.CountryName = country.CountryName;
                return CreatedAtAction(nameof(CreateLocationAsync), new { id = location.LocationID }, returner);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<LocationDTO>> UpdateLocationAsync(int id, UpdateLocationDTO locationDTO)
        {
            var existingLocaiton = await _locationRepository.GetLocationAsync(id);
            if (existingLocaiton is null)
            {
                return NotFound();
            }
            else
            {
                var location = new Location();
                location.CountryID = (await _countryRepository.GetCountryAsync(locationDTO.CountryName)).CountryID;
                location.CityID = (await _cityRepository.GetCityAsync(locationDTO.CityName)).CityID;
                await _locationRepository.UpdateLocationAsync(id, location);
                return NoContent();
            }
            
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLocationAsync(int id)
        {
            var existingLocaiton = await _locationRepository.GetLocationAsync(id);
            if (existingLocaiton is null)
            {
                return NotFound();
            }
            await _locationRepository.DeleteLocationAsync(id);
            return NoContent();
        }
    }
}
