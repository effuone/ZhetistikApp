using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhetistikApp.Api.DTOs.Portfolio;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortofolioController : ControllerBase
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IAchievementRepository _achievementRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IAchievementTypeRepository _achievementTypeRepository;
        private readonly ILogger<PortofolioController> _logger;

        public PortofolioController(IPortfolioRepository portfolioRepository, ILocationRepository locationRepository, ICountryRepository countryRepository, ICityRepository cityRepository, IAchievementRepository achievementRepository, ICandidateRepository candidateRepository, IAchievementTypeRepository achievementTypeRepository, ILogger<PortofolioController> logger)
        {
            _portfolioRepository = portfolioRepository;
            _locationRepository = locationRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _achievementRepository = achievementRepository;
            _candidateRepository = candidateRepository;
            _achievementTypeRepository = achievementTypeRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Portfolio>> GetPortfoliosAsync()
        {
            return await _portfolioRepository.GetPortfoliosAsync();
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<PortfolioDTO>> GetPortfolioAsync(int id)
        //{
        //    var portfolio = await _locationRepository.GetLocationAsync(id);
        //    if (portfolio is null)
        //    {
        //        return NotFound();
        //    }
        //    var returner = new PortfolioDTO();
        //    returner.
        //    return 
        //}
    }
}
