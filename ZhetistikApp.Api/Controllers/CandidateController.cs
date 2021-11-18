using Microsoft.AspNetCore.Mvc;
using ZhetistikApp.Api.DTOs.Candidate;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandidatesAsync()
        {
            try
            {
                var candidates = await _candidateRepository.GetAllCandidatesAsync();
                return Ok(candidates);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCandidateAsync(CreateCandidateDTO candidateDTO)
        {
            Candidate candidate = new() 
            { 
                UserID = candidateDTO.userID, 
                FirstName = candidateDTO.firstName, 
                LastName = candidateDTO.lastName, 
                Birthday = candidateDTO.birthday, 
                Email = candidateDTO.email, 
                PhoneNumber = candidateDTO.phoneNumber };

            try
            {
                candidate.CandidateID = await _candidateRepository.CreateCandidate(candidate);
                return Ok(candidate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
