using Microsoft.AspNetCore.Mvc;
using ZhetistikApp.Api.DTOs.Portfolio;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/portfolios/")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioController(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PortfolioDTO>> GetPortfolioAsync(int id)
        {
            try
            {
                var portfolio = await _portfolioRepository.GetPortfolioByIdAsync(id);
                return Ok(portfolio);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{firstName}+{lastName}")]
        public async Task<ActionResult<PortfolioDTO>> GetPortfolioByPersonAsync(string firstName, string lastName)
        {
            try
            {
                var portfolio = await _portfolioRepository.GetPortfolioByPersonAsync(firstName, lastName);
                if (portfolio is null)
                    return NotFound();
                return Ok(portfolio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{location}")]
        public async Task<ActionResult<PortfolioDTO>> GetPortfolioByLocationAsync(string countryName, string cityName)
        {
            try
            {
                var portfolio = await _portfolioRepository.GetPortfoliosByLocationAsync(countryName, cityName);
                if (portfolio is null)
                    return NotFound();
                return Ok(portfolio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<PortfolioDTO>> CreatePortfolioAsync(CreatePortfolioDTO portfolioDTO)
        {
            Portfolio portfolio = new()
            {
                CandidateID = portfolioDTO.CandidateID,
                PlacementID = portfolioDTO.PlacementID,
                AchievementID = portfolioDTO.AchievementID,
                IsPublished = portfolioDTO.IsPublished,
                CreatedDate = portfolioDTO.CreatedDate
            };
            try
            {
                portfolio.PortfolioID = await _portfolioRepository.CreatePortfolioAsync(portfolio);
                return Ok(portfolio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
