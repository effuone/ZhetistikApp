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
        public async Task<ActionResult<CandidateDTO>> GetAllCandidatesAsync()
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
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCandidate(int id)
        {
            try
            {
                var candidate = await _candidateRepository.GetCandidateByIdAsync(id);
                if (candidate is null)
                {
                    return NotFound();
                }
                return Ok(candidate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{firstName}+{lastName}")]
        public async Task<ActionResult> GetCandidateByName(string firstName, string lastName)
        {
            try
            {
                var candidate = await _candidateRepository.GetCandidateByName(firstName, lastName);
                if (candidate is null)
                    return NotFound();
                return Ok(candidate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateCandidate(CreateCandidateDTO candidateDTO)
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
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCandidate(int id, UpdateCandidateDTO candidate)
        {
            var newCandidate = new Candidate();
            newCandidate.CandidateID = id;
            newCandidate.UserID = candidate.UserID;
            newCandidate.LastName = candidate.LastName;
            newCandidate.FirstName = candidate.FirstName;
            newCandidate.Birthday = candidate.Birthday;
            newCandidate.Email = candidate.Email;
            newCandidate.PhoneNumber = candidate.PhoneNumber;
            await _candidateRepository.UpdateCandidateAsync(id, newCandidate);
            return Ok(candidate);
            //try
            //{
            //    await _candidateRepository.UpdateCandidateAsync(id, newCandidate);
            //    return Ok(candidate);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCandidate(int id)
        {
            await _candidateRepository.DeleteCandidateAsync(id);
            return NoContent();
        }
    }
}
