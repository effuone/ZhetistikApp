using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<CountryController> _logger;
        public CountryController(ICountryRepository countryRepository, ILogger<CountryController> logger)
        {
            _countryRepository = countryRepository;
            _logger = logger;
        }
       [HttpGet]
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await _countryRepository.GetCountriesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountryAsync(int id)
        {
            var country = await _countryRepository.GetCountryAsync(id);
            if(country is null)
            {
                return NotFound();
            }
            return country;
        }
        [HttpPost]
        public async Task<ActionResult<Country>> CreateCountryAsync(string countryName)
        {
            var existingCountry = await _countryRepository.GetCountryAsync(countryName);
            if(existingCountry is null)
            {
                var country = new Country();
                country.CountryName = countryName;
                country.CountryID = await _countryRepository.CreateCountryAsync(country);
                return CreatedAtAction(nameof(GetCountryAsync), new { id = country.CountryID }, country);
            }
            return StatusCode(409, $"Country {existingCountry.CountryName} already exists");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Country>> UpdateCountryAsync(int id, string countryName)
        {
            var existingCountry = await _countryRepository.GetCountryAsync(id);
            if (existingCountry is null)
            {
                return NotFound();
            }
            await _countryRepository.UpdateCountryAsync(id, new Country(id, countryName));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountryAsync(int id)
        {
            var existingCountry = await _countryRepository.GetCountryAsync(id);
            if(existingCountry is null)
            {
                return NotFound();
            }
            await _countryRepository.DeleteCountryAsync(id);
            return NoContent();
        }
    }
}
