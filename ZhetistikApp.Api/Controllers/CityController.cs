using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ZhetistikApp.Api.DTOs.Placement;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/cities")]
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
            //INPUT
            //CountryName CityName StateName
            //OUTPUT
            //CityID CountryName CityName StateName
            //TODO
            //Generate unique api for new location
            //BEFORE its neccessary to check whether location does not exist
            var result = await _cityRepository.DoesExist(cityDTO.CountryName, cityDTO.StateName, cityDTO.CityName);

            if (!result)
            {
                var countryId = ((await _countryRepository.GetCountryAsync(cityDTO.CountryName)).CountryID);
                var city = new City();
                city.CityName = cityDTO.CityName;
                city.CountryID = (await _cityRepository.GetCitiesAsync()).Where(x => x.CountryID == countryId).FirstOrDefault().CountryID;
                city.CityID = await _cityRepository.CreateCityAsync(city);
                //Saved in db
                //Now we have to return DTO object of names
                var ctdto = new CityDTO();
                ctdto.CityID = city.CityID;
                ctdto.CityName = city.CityName;
                ctdto.CountryName = (await _countryRepository.GetCountryAsync(countryId)).CountryName;
                return CreatedAtAction(nameof(GetCityAsync), new { id = ctdto.CityID }, ctdto);
            }
            return StatusCode(409, "This city already exists.");
        }
    }
}
