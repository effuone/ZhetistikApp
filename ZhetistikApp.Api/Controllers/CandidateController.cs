using Microsoft.AspNetCore.Mvc;
using ZhetistikApp.Api.DTOs.Candidate;
using ZhetistikApp.Api.DTOs;
using ZhetistikApp.Api.Interfaces;
using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ILogger<CandidateController> _logger;

        public CandidateController(ICandidateRepository candidateRepository, ILogger<CandidateController> logger)
        {
            _candidateRepository = candidateRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<CandidateDTO>> GetAllCandidatesAsync()
        {
            var candidates = (await _candidateRepository.GetAllCandidatesAsync()).Select(x => x.AsDto());
            _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")} : Retrieved {candidates.Count()} candidates");
            return candidates;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateDTO>> GetCandidateAsync(int id)
        {
            var candidate = await _candidateRepository.GetCandidateByIdAsync(id);
            if (candidate is null)
            {
                return NotFound();
            }
            return candidate.AsDto();
        }
        [HttpGet("{firstName}+{lastName}")]
        public async Task<ActionResult<CandidateDTO>> GetCandidateByNameAsync(string firstName, string lastName)
        {
            var candidate = await _candidateRepository.GetCandidateByName(firstName, lastName);
            if (candidate is null)
                return NotFound();
            return candidate.AsDto();
        }
        [HttpPost]
        public async Task<ActionResult<CandidateDTO>> CreateCandidateAsync(CreateCandidateDTO candidateDTO)
        {
            Candidate candidate = new()
            {
                FirstName = candidateDTO.FirstName,
                LastName = candidateDTO.LastName,
                Birthday = candidateDTO.Birthday,
                Email = candidateDTO.Email,
                PhoneNumber = candidateDTO.PhoneNumber
            };

            candidate.CandidateID = await _candidateRepository.CreateCandidate(candidate);
            return CreatedAtAction(nameof(GetCandidateAsync), new { id = candidate.CandidateID }, candidate.AsDto());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCandidate(int id, UpdateCandidateDTO candidate)
        {
            var existingCandidate = await _candidateRepository.GetCandidateByIdAsync(id);
            if (existingCandidate is null)
            {
                return NotFound();
            }
            var newCandidate = new Candidate();
            newCandidate.CandidateID = id;
            newCandidate.LastName = candidate.LastName;
            newCandidate.FirstName = candidate.FirstName;
            newCandidate.Birthday = candidate.Birthday;
            newCandidate.Email = candidate.Email;
            newCandidate.PhoneNumber = candidate.PhoneNumber;
            await _candidateRepository.UpdateCandidateAsync(id, newCandidate);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCandidate(int id)
        {
            var existingCandidate = await _candidateRepository.GetCandidateByIdAsync(id);
            if (existingCandidate is null)
            {
                return NotFound();
            }
            await _candidateRepository.DeleteCandidateAsync(id);
            return NoContent();
        }
    }
}
