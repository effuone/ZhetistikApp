using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface ICandidateRepository
    {
        //GET candidate by id
        //GET candidate by user id
        //GET candidate by name
        //CREATE candidate
        //UPDATE candidate
        //DELETE candidate
        Task<Candidate> GetCandidateByIdAsync(long id);
        Task<Candidate> GetCandidateByUserIdAsync(long userId);
        Task<Candidate> GetCandidateByName(string firstName, string lastName);
        Task<IEnumerable<Candidate>> GetAllCandidatesAsync();
        Task<long> CreateCandidate(Candidate candidate);
        Task UpdateCandidateAsync(Candidate candidate);
        Task DeleteCandidateAsync(long id);
    }
}
