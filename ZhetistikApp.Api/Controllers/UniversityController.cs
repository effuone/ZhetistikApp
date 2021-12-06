using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhetistikApp.Api.DTOs.University;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IUniversityTypeRepository _universityTypeRepository;
        private readonly ILogger<UniversityController> _logger;

        public UniversityController(IUniversityRepository universityRepository, ICountryRepository countryRepository, ICityRepository cityRepository, ILocationRepository locationRepository, IUniversityTypeRepository universityTypeRepository, ILogger<UniversityController> logger)
        {
            _universityRepository = universityRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _locationRepository = locationRepository;
            _universityTypeRepository = universityTypeRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<University>> GetUniversitiesAsync()
        {
            return await _universityRepository.GetUniversitiesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<University>> GetUniversityAsync(int id)
        {
            var university = await _universityRepository.GetUniversityAsync(id);
            if (university is null)
            {
                return NotFound();
            }
            return university;
        }
        [HttpPost]
        public async Task<ActionResult<University>> CreateUniversityAsync(UniversityDTO universityDTO)
        {
            var existingUniversity = await _universityRepository.GetUniversityAsync(universityDTO.UniversityName);
            var existingCountry = await _countryRepository.GetCountryAsync(universityDTO.CountryName);
            var existingCity = await _cityRepository.GetCityAsync(universityDTO.CityName);
            var existingType = await _universityTypeRepository.GetUniversityTypeAsync(universityDTO.UniversityTypeName);
            if(existingCity is null)
            {
                return StatusCode(404, $"City {universityDTO.CityName} not founded");
            }
            if (existingCountry is null)
            {
                return StatusCode(404, $"Country {universityDTO.CountryName} not founded");
            }
            if (existingCountry is null)
            {
                return StatusCode(404, $"University type {universityDTO.UniversityTypeName} not founded");
            }
            if (existingUniversity is null)
            {
                var university = new University();
                university.UniversityName = universityDTO.UniversityName;
                university.UniversityDescription = universityDTO.UniversityDescription;
                university.FoundationYear = universityDTO.FoundationYear;
                university.StudentsCount = universityDTO.StudentsCount;
                university.UniversityTypeID = existingType.UniversityTypeID;
                university.LocationID = (await _locationRepository.GetLocationAsync(universityDTO.CityName)).LocationID;
                return CreatedAtAction(nameof(CreateUniversityAsync), new { id = university.UniversityID }, university);
            }
            return StatusCode(409, $"University {universityDTO.UniversityName} already exists");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<University>> UpdateUniversityAsync(int id, UniversityDTO universityDTO)
        {
            var existingUniversity = await _universityRepository.GetUniversityAsync(id);
            if(existingUniversity == null)
            {
                return NotFound();
            }
            var existingType = await _universityTypeRepository.GetUniversityTypeAsync(universityDTO.UniversityTypeName);
            if(existingType == null)
            {
                return StatusCode(404, $"University type {universityDTO.UniversityTypeName} not founded");
            }
            var existingCountry = await _countryRepository.GetCountryAsync(universityDTO.CountryName);
            if(existingCountry == null)
            {
                return StatusCode(404, $"Country {universityDTO.UniversityTypeName} not founded");
            }
            var existingCity = await _cityRepository.GetCityAsync(universityDTO.CityName);
            if (existingCity is null)
            {
                return StatusCode(404, $"City {universityDTO.CityName} not founded");
            }
            var university = new University();
            university.UniversityName = universityDTO.UniversityName;
            university.UniversityDescription = universityDTO.UniversityDescription;
            university.StudentsCount = universityDTO.StudentsCount;
            university.FoundationYear = universityDTO.FoundationYear;
            university.UniversityTypeID = existingType.UniversityTypeID;
            university.LocationID = (await _locationRepository.GetLocationAsync(existingCity.CityID)).LocationID;
            await _universityRepository.UpdateUniversityAsync(id, university);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUniversityAsync (int id)
        {
            var existingUniversity = await _universityRepository.GetUniversityAsync(id);
            if (existingUniversity == null)
            {
                return NotFound();
            }
            await _universityRepository.DeleteUniversityAsync(id);
            return NoContent();
        }
    }
}
