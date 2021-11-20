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
        Task<Candidate> GetCandidateByIdAsync(int id);
        Task<Candidate> GetCandidateByName(string firstName, string lastName);
        Task<IEnumerable<Candidate>> GetAllCandidatesAsync();
        Task<int> CreateCandidate(Candidate candidate);
        Task UpdateCandidateAsync(int id, Candidate candidate);
        Task DeleteCandidateAsync(int id);
    }
}
