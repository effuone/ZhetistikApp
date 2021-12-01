using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ZhetistikApp.Api.DTOs.Placement;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/cities/")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<CityController> _logger;

        public CityController(ICityRepository cityRepository, ICountryRepository countryRepository, ILogger<CityController> logger)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _cityRepository.GetCitiesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCityAsync(int id)
        {
            var city = await _cityRepository.GetCityAsync(id);
            if(city is null)
            {
                return NotFound(); 
            }
            return city;
        }
        [HttpPost]
        public async Task<ActionResult<CityDTO>> CreateCityAsync(CreateCityDTO cityDTO)
        {
            var existingCountry = await _countryRepository.GetCountryAsync(cityDTO.CountryName);
            if(existingCountry is null)
            {
                var country = new Country();
                country.CountryName = cityDTO.CountryName;
                country.CountryID = await _countryRepository.CreateCountryAsync(country);
                var city = new City();
                city.CityName = cityDTO.CityName;
                city.CountryID = country.CountryID;
                city.CityID = await _cityRepository.CreateCityAsync(city);
                var returner = new CityDTO();
                returner.CityID = city.CityID;
                returner.CityName = cityDTO.CityName;
                returner.CountryName = country.CountryName;
                return CreatedAtAction(nameof(CreateCityAsync), new { id = city.CityID }, returner);
            }
            else
            {
                var existingCity = await _cityRepository.GetCityAsync(cityDTO.CityName);
                if(existingCity is null)
                {
                    var city = new City();
                    city.CityName = cityDTO.CityName;
                    city.CountryID = existingCountry.CountryID;
                    city.CityID = await _cityRepository.CreateCityAsync(city);
                    var returner = new CityDTO();
                    returner.CityID = city.CityID;
                    returner.CityName = cityDTO.CityName;
                    returner.CountryName = existingCountry.CountryName;
                    return CreatedAtAction(nameof(CreateCityAsync), new { id = city.CityID }, returner);
                }
                else
                {
                    return StatusCode(409, $"City {existingCity.CityName} of {await _countryRepository.GetCountryAsync(existingCity.CountryID)} already exists");
                }
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CityDTO>> UpdateCityAsync(int id, UpdateCityDTO cityDTO)
        {
            var existingCity = await _cityRepository.GetCityAsync(id);
            if(existingCity is null)
            {
                return NotFound();
            }
            var existingCountry = await _countryRepository.GetCountryAsync(cityDTO.CountryName);
            var city = new City();
            city.CityName = cityDTO.CityName;
            city.CountryID = existingCountry.CountryID;
            city.CityID = id;
            await _cityRepository.UpdateCityAsync(id, city);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCityAsync(int id)
        {
            var existingCity = await _cityRepository.GetCityAsync(id);
            if (existingCity is null)
            {
                return NotFound();
            }
            await _cityRepository.DeleteCityAsync(id);
            return NoContent();
        }
    }
}
